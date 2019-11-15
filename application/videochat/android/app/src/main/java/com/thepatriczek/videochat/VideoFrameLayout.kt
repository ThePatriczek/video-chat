package com.thepatriczek.videochat

import android.content.Context
import android.view.MotionEvent
import android.widget.FrameLayout
import android.util.AttributeSet

class VideoFrameLayout(context: Context, attrs: AttributeSet?) : FrameLayout(context, attrs) {

    private var listener: IVideoFrameListener? = null
    private var downX: Float = 0.toFloat()
    private var downY: Float = 0.toFloat()
    private val SCROLL_THRESHOLD = 10f
    private var isOnClick: Boolean = false

    fun Register(listener: IVideoFrameListener) {
        this.listener = listener
    }

    override fun dispatchTouchEvent(ev: MotionEvent): Boolean {
        when (ev.action and MotionEvent.ACTION_MASK) {
            MotionEvent.ACTION_DOWN -> {
                downX = ev.x
                downY = ev.y
                isOnClick = true
            }
            MotionEvent.ACTION_CANCEL, MotionEvent.ACTION_UP -> if (isOnClick) {
                listener!!.onVideoFrameClicked()
            }
            MotionEvent.ACTION_MOVE -> if (isOnClick && (Math.abs(downX - ev.x) > SCROLL_THRESHOLD || Math.abs(downY - ev.y) > SCROLL_THRESHOLD)) {
                isOnClick = false
            }
            else -> {
            }
        }
        return super.dispatchTouchEvent(ev)
    }
}
