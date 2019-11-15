package com.thepatriczek.videochat

import android.Manifest
import android.annotation.TargetApi
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Build
import android.os.Bundle
import android.view.ViewTreeObserver
import android.widget.EditText
import android.widget.ProgressBar
import android.widget.TextView
import android.app.Activity
import android.graphics.Bitmap
import android.net.Uri
import android.os.Environment
import android.view.View
import android.view.WindowManager
import android.widget.LinearLayout
import android.widget.ToggleButton
import androidx.annotation.RequiresApi

import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat

import com.vidyo.VidyoClient.Connector.ConnectorPkg
import com.vidyo.VidyoClient.Connector.Connector
import com.vidyo.VidyoClient.Device.Device
import com.vidyo.VidyoClient.Device.LocalCamera
import com.vidyo.VidyoClient.Endpoint.LogRecord
import com.vidyo.VidyoClient.NetworkInterface
import com.vidyo.videochat.R
import java.io.File
import java.io.FileOutputStream
import java.util.*

class MainActivity : Activity(), View.OnClickListener, Connector.IConnect, Connector.IRegisterLogEventListener, Connector.IRegisterNetworkInterfaceEventListener, Connector.IRegisterLocalCameraEventListener, IVideoFrameListener {

    private val PERMISSIONS_REQUEST_ALL: Int = 1988

    private var connectorState = State.Disconnected
    private var connector: Connector? = null
    private var localCamera: LocalCamera? = null
    private var toggleConnectButton: ToggleButton? = null
    private var toggleMicrophoneButton: ToggleButton? = null
    private var toggleCameraButton: ToggleButton? = null
    private var connectionSpinner: ProgressBar? = null
    private var controlsLayout: LinearLayout? = null
    private var toolbarLayout: LinearLayout? = null
    private var host: EditText? = null
    private var displayName: EditText? = null
    private var token: EditText? = null
    private var resource: EditText? = null
    private var toolbarStatus: TextView? = null
    private var videoFrame: VideoFrameLayout? = null
    private var hideConfig = false
    private var autoJoin = false
    private var allowReconnect = true
    private var cameraPrivacy = false
    private var microphonePrivacy = false
    private var enableDebug = false
    private var returnUrl: String? = null
    private var experimentalOptions: String? = null
    private var refreshSettings = true
    private var devicesSelected = true
    private var onGlobalLayoutListener: ViewTreeObserver.OnGlobalLayoutListener? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_main)

        controlsLayout = findViewById(R.id.controlsLayout)
        toolbarLayout = findViewById(R.id.toolbarLayout)
        videoFrame = findViewById(R.id.videoFrame)
        videoFrame!!.register(this)
        host = findViewById(R.id.hostTextBox)
        displayName = findViewById(R.id.displayNameTextBox)
        token = findViewById(R.id.tokenTextBox)
        resource = findViewById(R.id.resourceIdTextBox)
        toolbarStatus = findViewById(R.id.toolbarStatusText)
        connectionSpinner = findViewById(R.id.connectionSpinner)

        toggleConnectButton = findViewById(R.id.connect)
        toggleConnectButton!!.setOnClickListener(this)
        toggleMicrophoneButton = findViewById(R.id.microphone_privacy)
        toggleMicrophoneButton!!.setOnClickListener(this)
        toggleCameraButton = findViewById(R.id.camera_privacy)
        toggleCameraButton!!.setOnClickListener(this)

        ConnectorPkg.setApplicationUIContext(this)

        if (ConnectorPkg.initialize()) {
            try {
                connector = Connector(videoFrame,
                        Connector.ConnectorViewStyle.VIDYO_CONNECTORVIEWSTYLE_Default,
                        7,
                        "info@VidyoClient info@VidyoConnector warning",
                        "",
                        0)

                if (Build.VERSION.SDK_INT > 22) {
                    val permissionsNeeded = ArrayList<String>()
                    for (permission in permissions) {
                        if (ContextCompat.checkSelfPermission(this, permission) != PackageManager.PERMISSION_GRANTED)
                            permissionsNeeded.add(permission)
                    }
                    if (permissionsNeeded.size > 0) {
                        ActivityCompat.requestPermissions(this, permissionsNeeded.toTypedArray(), PERMISSIONS_REQUEST_ALL)
                    } else {
                        this.startVideoViewSizeListener()
                    }
                } else {
                    this.startVideoViewSizeListener()
                }
            } catch (e: Exception) {
                e.printStackTrace()
            }

        }
    }

    override fun onNewIntent(intent: Intent) {
        super.onNewIntent(intent)

        refreshSettings = true
        setIntent(intent)
    }

    override fun onStart() {
        super.onStart()

        if (refreshSettings &&
                connectorState != State.Connected &&
                connectorState != State.Connecting) {

            val intent = intent
            val uri = intent.data

            if (uri != null) {
                var param = uri.getQueryParameter("host")
                host!!.setText(param ?: "prod.vidyo.io")

                param = uri.getQueryParameter("token")
                token!!.setText(param ?: "")

                param = uri.getQueryParameter("displayName")
                displayName!!.setText(param ?: "DemoUser")

                param = uri.getQueryParameter("resourceId")
                resource!!.setText(param ?: "DemoRoom")

                returnUrl = uri.getQueryParameter("returnURL")
                hideConfig = uri.getBooleanQueryParameter("hideConfig", false)
                autoJoin = uri.getBooleanQueryParameter("autoJoin", false)
                allowReconnect = uri.getBooleanQueryParameter("allowReconnect", true)
                cameraPrivacy = uri.getBooleanQueryParameter("cameraPrivacy", false)
                microphonePrivacy = uri.getBooleanQueryParameter("microphonePrivacy", false)
                enableDebug = uri.getBooleanQueryParameter("enableDebug", false)
                experimentalOptions = uri.getQueryParameter("experimentalOptions")
            } else {
                host!!.setText(if (intent.hasExtra("host")) intent.getStringExtra("host") else "prod.vidyo.io")
                token!!.setText(if (intent.hasExtra("token")) intent.getStringExtra("token") else "")
                displayName!!.setText(if (intent.hasExtra("displayName")) intent.getStringExtra("displayName") else "DemoUser")
                resource!!.setText(if (intent.hasExtra("resourceId")) intent.getStringExtra("resourceId") else "DemoRoom")
                returnUrl = if (intent.hasExtra("returnURL")) intent.getStringExtra("returnURL") else null
                hideConfig = intent.getBooleanExtra("hideConfig", false)
                autoJoin = intent.getBooleanExtra("autoJoin", false)
                allowReconnect = intent.getBooleanExtra("allowReconnect", true)
                cameraPrivacy = intent.getBooleanExtra("cameraPrivacy", false)
                microphonePrivacy = intent.getBooleanExtra("microphonePrivacy", false)
                enableDebug = intent.getBooleanExtra("enableDebug", false)
                experimentalOptions = if (intent.hasExtra("experimentalOptions")) intent.getStringExtra("experimentalOptions") else null
            }

            if (hideConfig) {
                controlsLayout!!.visibility = View.GONE
            }

            this.applySettings()
        }
        refreshSettings = false
    }

    override fun onStop() {

        super.onStop()

        if (connector != null) {
            if (connectorState != State.Connected && connectorState != State.Connecting) {
                connector!!.selectLocalCamera(null)
                connector!!.selectLocalMicrophone(null)
                connector!!.selectLocalSpeaker(null)
                devicesSelected = false
            }
            connector!!.setMode(Connector.ConnectorMode.VIDYO_CONNECTORMODE_Background)
        }
    }

    override fun onRestart() {
        super.onRestart()

        if (connector != null) {
            connector!!.setMode(Connector.ConnectorMode.VIDYO_CONNECTORMODE_Foreground)

            if (!devicesSelected) {
                devicesSelected = true

                connector!!.selectLocalCamera(localCamera)
                connector!!.selectDefaultMicrophone()
                connector!!.selectDefaultSpeaker()
                connector!!.setCameraPrivacy(cameraPrivacy)
                connector!!.setMicrophonePrivacy(microphonePrivacy)
            }
        }
    }

    override fun onDestroy() {
        super.onDestroy()

        localCamera = null

        if (connector != null) {
            connector!!.selectLocalCamera(null)
            connector!!.selectLocalMicrophone(null)
            connector!!.selectLocalSpeaker(null)
        }

        connector = null

        ConnectorPkg.setApplicationUIContext(null)
        ConnectorPkg.uninitialize()

        if (onGlobalLayoutListener != null) {
            videoFrame!!.viewTreeObserver.removeOnGlobalLayoutListener(onGlobalLayoutListener)
        }
    }

    override fun onRequestPermissionsResult(requestCode: Int, permissions: Array<String>, grantResults: IntArray) {
        if (requestCode == PERMISSIONS_REQUEST_ALL) {
            for (i in permissions.indices) {
                this.startVideoViewSizeListener()
            }
        }
    }

    private fun startVideoViewSizeListener() {
        val viewTreeObserver = videoFrame!!.viewTreeObserver

        if (viewTreeObserver.isAlive) {
            viewTreeObserver.addOnGlobalLayoutListener(object : ViewTreeObserver.OnGlobalLayoutListener {
                override fun onGlobalLayout() {
                    connector!!.showViewAt(videoFrame, 0, 0, videoFrame!!.width, videoFrame!!.height)
                    onGlobalLayoutListener = this
                }
            })
        }
    }

    private fun applySettings() {
        if (connector != null) {
            if (enableDebug) {
                connector!!.enableDebug(7776, "warning info@VidyoClient info@VidyoConnector")
            } else {
                connector!!.disableDebug()
            }

            toggleCameraButton!!.isChecked = false

            if (cameraPrivacy) {
                toggleCameraButton!!.performClick()
            }

            toggleMicrophoneButton!!.isChecked = false

            if (microphonePrivacy) {
                toggleMicrophoneButton!!.performClick()
            }

            if (experimentalOptions != null) {
                ConnectorPkg.setExperimentalOptions(experimentalOptions)
            }

            if (autoJoin) {
                toggleConnectButton!!.performClick()
            }
        }
    }

    private fun changeState(state: State) {

        connectorState = state

        runOnUiThread {
            toolbarStatus!!.text = stateDescription[connectorState]

            when (connectorState) {
                State.Connecting -> {
                    toggleConnectButton!!.isChecked = true
                    connectionSpinner!!.visibility = View.VISIBLE
                }

                State.Connected -> {
                    toggleConnectButton!!.isChecked = true
                    controlsLayout!!.visibility = View.GONE
                    connectionSpinner!!.visibility = View.INVISIBLE

                    window.addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON)
                }

                State.Disconnecting ->
                    toggleConnectButton!!.isChecked = true

                State.Disconnected, State.DisconnectedUnexpected, State.Failure, State.FailureInvalidResource -> {
                    toggleConnectButton!!.isChecked = false
                    toolbarLayout!!.visibility = View.VISIBLE
                    connectionSpinner!!.visibility = View.INVISIBLE

                    if (returnUrl != null) {
                        val returnApp = packageManager.getLaunchIntentForPackage(returnUrl!!)
                        returnApp!!.putExtra("callstate", if (connectorState == State.Disconnected) 1 else 0)
                        startActivity(returnApp)
                    }

                    if (!allowReconnect && connectorState == State.Disconnected) {
                        toggleConnectButton!!.isEnabled = false
                        toolbarStatus!!.text = "Call ended"
                    }

                    if (!hideConfig) {
                        controlsLayout!!.visibility = View.VISIBLE
                    }


                    window.clearFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON)
                }
            }
        }
    }

    @TargetApi(Build.VERSION_CODES.O)
    @RequiresApi(Build.VERSION_CODES.O)
    override fun onClick(view: View) {
        if (connector != null) {
            when (view.id) {
                R.id.connect ->
                    this.toggleConnect()

                R.id.camera_switch ->
                    connector!!.cycleCamera()

                R.id.camera_privacy -> {
                    cameraPrivacy = toggleCameraButton!!.isChecked
                    connector!!.setCameraPrivacy(cameraPrivacy)
                }

                R.id.microphone_privacy -> {
                    microphonePrivacy = toggleMicrophoneButton!!.isChecked
                    connector!!.setMicrophonePrivacy(microphonePrivacy)
                }

                R.id.screenshot ->
                    takeScreenshot()

            }
        }
    }

    private fun toggleConnect() {
        if (toggleConnectButton!!.isChecked) {

            val resourceId = resource!!.text.toString().trim { it <= ' ' }

            if (resourceId.contains(" ") || resourceId.contains("@")) {
                this.changeState(State.FailureInvalidResource)
            } else {
                this.changeState(State.Connecting)

                if (!connector!!.connect(
                                host!!.text.toString().trim { it <= ' ' },
                                token!!.text.toString().trim { it <= ' ' },
                                displayName!!.text.toString().trim { it <= ' ' },
                                resourceId,
                                this)) {
                    this.changeState(State.Failure)
                }
            }

        } else {
            this.changeState(State.Disconnecting)
            connector!!.disconnect()
        }
    }

    override fun onVideoFrameClicked() {
        if (connectorState == State.Connected) {
            if (toolbarLayout!!.visibility == View.VISIBLE) {
                toolbarLayout!!.visibility = View.INVISIBLE
            } else {
                toolbarLayout!!.visibility = View.VISIBLE
            }
        }
    }

    override fun onSuccess() {
        this.changeState(State.Connected)
    }

    override fun onFailure(reason: Connector.ConnectorFailReason) {
        this.changeState(State.Failure)
    }

    override fun onDisconnected(reason: Connector.ConnectorDisconnectReason) {
        if (reason == Connector.ConnectorDisconnectReason.VIDYO_CONNECTORDISCONNECTREASON_Disconnected) {
            this.changeState(State.Disconnected)
        } else {
            this.changeState(State.DisconnectedUnexpected)
        }
    }

    override fun onLocalCameraAdded(localCamera: LocalCamera) {}

    override fun onLocalCameraRemoved(localCamera: LocalCamera) {}

    override fun onLocalCameraSelected(localCamera: LocalCamera?) {
        if (localCamera != null) {
            this.localCamera = localCamera
        }
    }

    override fun onLocalCameraStateUpdated(localCamera: LocalCamera, state: Device.DeviceState) {}

    override fun onLog(logRecord: LogRecord) {}

    override fun onNetworkInterfaceAdded(vidyoNetworkInterface: NetworkInterface) {}

    override fun onNetworkInterfaceRemoved(vidyoNetworkInterface: NetworkInterface) {}

    override fun onNetworkInterfaceSelected(vidyoNetworkInterface: NetworkInterface, vidyoNetworkInterfaceTransportType: NetworkInterface.NetworkInterfaceTransportType) {}

    override fun onNetworkInterfaceStateUpdated(vidyoNetworkInterface: NetworkInterface, vidyoNetworkInterfaceState: NetworkInterface.NetworkInterfaceState) {}

    companion object {

        private val stateDescription = object : HashMap<State, String>() {
            init {
                put(State.Connecting, "Connecting...")
                put(State.Connected, "Connected")
                put(State.Disconnecting, "Disconnecting...")
                put(State.Disconnected, "Disconnected")
                put(State.DisconnectedUnexpected, "Unexpected disconnection")
                put(State.Failure, "Connection failed")
                put(State.FailureInvalidResource, "Invalid Resource ID")
            }
        }

        private val permissions = arrayOf(Manifest.permission.CAMERA, Manifest.permission.RECORD_AUDIO, Manifest.permission.WRITE_EXTERNAL_STORAGE, Manifest.permission.READ_PHONE_STATE)
    }

    @RequiresApi(Build.VERSION_CODES.O)
    private fun takeScreenshot() {
        try {
            val path: String = Environment.getExternalStorageDirectory().toString() + "/" + Date().toInstant().toString() + ".jpg"

            val view = window.decorView.rootView
            view.isDrawingCacheEnabled = true
            val bitmap = Bitmap.createBitmap(view.drawingCache)
            view.isDrawingCacheEnabled = false

            val imageFile = File(path)

            val outputStream = FileOutputStream(imageFile)
            val quality = 100
            bitmap.compress(Bitmap.CompressFormat.JPEG, quality, outputStream)
            outputStream.flush()
            outputStream.close()

//            openScreenshot(imageFile)
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }

    private fun openScreenshot(imageFile: File) {
        val intent = Intent()
        intent.action = Intent.ACTION_VIEW

        val uri = Uri.fromFile(imageFile)
        intent.setDataAndType(uri, "image/*")
        startActivity(intent)
    }
}
