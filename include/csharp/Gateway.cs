// DO NOT EDIT! This is an autogenerated file. All changes will be
// overwritten!

//	Copyright (c) 2016 Vidyo, Inc. All rights reserved.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace VidyoClient
{
	public class Gateway{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		private IntPtr objPtr; // opaque VidyoGateway reference.
		public IntPtr GetObjectPtr(){
			return objPtr;
		}
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern Boolean VidyoGatewayConnectNative(IntPtr gateway, IntPtr host, IntPtr token, IntPtr displayName, IntPtr resourceId, OnSuccess onSuccess, OnFailure onFailure, OnDisconnected onDisconnected);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoGatewayConstructCopyNative(IntPtr other);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoGatewayDestructNative(IntPtr gateway);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoGatewayDisconnectNative(IntPtr gateway);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr VidyoGatewayGetUserDataNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern void VidyoGatewaySetUserDataNative(IntPtr obj, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void OnDisconnected(IntPtr gateway, GatewayDisconnectReason reason);
		private OnDisconnected _mOnDisconnected;
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void OnFailure(IntPtr gateway, GatewayFailReason reason);
		private OnFailure _mOnFailure;
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void OnSuccess(IntPtr gateway);
		private OnSuccess _mOnSuccess;
		public enum GatewayDisconnectReason{
			GatewaydisconnectreasonDisconnected,
			GatewaydisconnectreasonConnectionLost,
			GatewaydisconnectreasonConnectionTimeout,
			GatewaydisconnectreasonNoResponse,
			GatewaydisconnectreasonTerminated,
			GatewaydisconnectreasonMiscLocalError,
			GatewaydisconnectreasonMiscRemoteError,
			GatewaydisconnectreasonMiscError
		}
		public enum GatewayFailReason{
			GatewayfailreasonConnectionFailed,
			GatewayfailreasonConnectionLost,
			GatewayfailreasonConnectionTimeout,
			GatewayfailreasonNoResponse,
			GatewayfailreasonTerminated,
			GatewayfailreasonInvalidToken,
			GatewayfailreasonUnableToCreateResource,
			GatewayfailreasonNoResponseFromResource,
			GatewayfailreasonInvalidResourceId,
			GatewayfailreasonResourceFull,
			GatewayfailreasonNotMember,
			GatewayfailreasonBanned,
			GatewayfailreasonMediaNotEnabled,
			GatewayfailreasonMediaFailed,
			GatewayfailreasonMiscLocalError,
			GatewayfailreasonMiscRemoteError,
			GatewayfailreasonMiscError
		}
		public enum GatewayState{
			GatewaystateIdle,
			GatewaystateEstablishingConnection,
			GatewaystateFindingResource,
			GatewaystateConnectingToResource,
			GatewaystateEnablingMedia,
			GatewaystateConnected
		}
		public interface IConnect{

			void OnSuccess();
			void OnFailure(GatewayFailReason reason);
			void OnDisconnected(GatewayDisconnectReason reason);
		}
		private IConnect _mIConnect;
		public Gateway(IntPtr other){
			objPtr = VidyoGatewayConstructCopyNative(other);
			VidyoGatewaySetUserDataNative(objPtr, GCHandle.ToIntPtr(GCHandle.Alloc(this, GCHandleType.Weak)));
		}
		~Gateway(){
			if(objPtr != IntPtr.Zero){
				VidyoGatewaySetUserDataNative(objPtr, IntPtr.Zero);
				VidyoGatewayDestructNative(objPtr);
			}
		}
		public Boolean Connect(String host, String token, String displayName, String resourceId, IConnect _iIConnect){
			_mIConnect = _iIConnect;
			_mOnSuccess = OnSuccessDelegate;
			_mOnFailure = OnFailureDelegate;
			_mOnDisconnected = OnDisconnectedDelegate;

			IntPtr nHost = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(host ?? string.Empty);
			IntPtr nToken = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(token ?? string.Empty);
			IntPtr nDisplayName = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(displayName ?? string.Empty);
			IntPtr nResourceId = MarshalPtrToUtf8.GetInstance().MarshalManagedToNative(resourceId ?? string.Empty);
			Boolean ret = VidyoGatewayConnectNative(objPtr, nHost, nToken, nDisplayName, nResourceId, _mOnSuccess, _mOnFailure, _mOnDisconnected);
			Marshal.FreeHGlobal(nResourceId);
			Marshal.FreeHGlobal(nDisplayName);
			Marshal.FreeHGlobal(nToken);
			Marshal.FreeHGlobal(nHost);

			return ret;
		}
		public void Disconnect(){

			VidyoGatewayDisconnectNative(objPtr);
		}
#if __IOS__
[ObjCRuntime.MonoPInvokeCallback(typeof(OnDisconnected))]
#endif
		private static void OnDisconnectedDelegate(IntPtr gateway, GatewayDisconnectReason reason){
			Gateway csGateway = null;
			if(gateway != IntPtr.Zero){
				if(Gateway.VidyoGatewayGetUserDataNative(gateway) == IntPtr.Zero)
					csGateway = new Gateway(gateway);
				else{
					GCHandle objHandle = (GCHandle)Gateway.VidyoGatewayGetUserDataNative(gateway);
					csGateway = (Gateway)objHandle.Target;
				}
			}
			if(csGateway._mIConnect != null)
				csGateway._mIConnect.OnDisconnected(reason);
		}
#if __IOS__
[ObjCRuntime.MonoPInvokeCallback(typeof(OnFailure))]
#endif
		private static void OnFailureDelegate(IntPtr gateway, GatewayFailReason reason){
			Gateway csGateway = null;
			if(gateway != IntPtr.Zero){
				if(Gateway.VidyoGatewayGetUserDataNative(gateway) == IntPtr.Zero)
					csGateway = new Gateway(gateway);
				else{
					GCHandle objHandle = (GCHandle)Gateway.VidyoGatewayGetUserDataNative(gateway);
					csGateway = (Gateway)objHandle.Target;
				}
			}
			if(csGateway._mIConnect != null)
				csGateway._mIConnect.OnFailure(reason);
		}
#if __IOS__
[ObjCRuntime.MonoPInvokeCallback(typeof(OnSuccess))]
#endif
		private static void OnSuccessDelegate(IntPtr gateway){
			Gateway csGateway = null;
			if(gateway != IntPtr.Zero){
				if(Gateway.VidyoGatewayGetUserDataNative(gateway) == IntPtr.Zero)
					csGateway = new Gateway(gateway);
				else{
					GCHandle objHandle = (GCHandle)Gateway.VidyoGatewayGetUserDataNative(gateway);
					csGateway = (Gateway)objHandle.Target;
				}
			}
			if(csGateway._mIConnect != null)
				csGateway._mIConnect.OnSuccess();
		}
	};
}
