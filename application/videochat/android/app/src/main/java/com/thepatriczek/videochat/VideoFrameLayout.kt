package com.thepatriczek.videochat

import android.content.Context
import android.view.MotionEvent
import android.widget.FrameLayout
import android.util.AttributeSet
import kotlin.math.abs

class VideoFrameLayout(context: Context, attrs: AttributeSet?) : FrameLayout(context, attrs) {

    private var listener: IVideoFrameListener? = null
    private var downX: Float = 0.toFloat()
    private var downY: Float = 0.toFloat()
    private val SCROLL_THRESHOLD = 10f
    private var isOnClick: Boolean = false

    fun register(listener: IVideoFrameListener) {
        this.listener = listener
    }

    override fun dispatchTouchEvent(event: MotionEvent): Boolean {
        when (event.action and MotionEvent.ACTION_MASK) {
            MotionEvent.ACTION_DOWN -> {
                downX = event.x
                downY = event.y
                isOnClick = true
            }

            MotionEvent.ACTION_CANCEL, MotionEvent.ACTION_UP -> if (isOnClick) {
                listener!!.onVideoFrameClicked()
            }

            MotionEvent.ACTION_MOVE -> if (isOnClick && (abs(downX - event.x) > SCROLL_THRESHOLD || abs(downY - event.y) > SCROLL_THRESHOLD)) {
                isOnClick = false
            }
        }

        return super.dispatchTouchEvent(event)
    }
}
