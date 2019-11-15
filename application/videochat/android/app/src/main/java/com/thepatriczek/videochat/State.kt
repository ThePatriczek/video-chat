package com.thepatriczek.videochat

enum class State {
    Connecting,
    Connected,
    Disconnecting,
    Disconnected,
    DisconnectedUnexpected,
    Failure,
    FailureInvalidResource
}