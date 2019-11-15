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
	public class NetworkInterfaceStatsFactory
	{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr VidyoNetworkInterfaceStatsConstructDefaultNative();
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern void VidyoNetworkInterfaceStatsDestructNative(IntPtr obj);
		public static NetworkInterfaceStats Create()
		{
			IntPtr objPtr = VidyoNetworkInterfaceStatsConstructDefaultNative();
			return new NetworkInterfaceStats(objPtr);
		}
		public static void Destroy(NetworkInterfaceStats obj)
		{
			VidyoNetworkInterfaceStatsDestructNative(obj.GetObjectPtr());
		}
	}
	public class NetworkInterfaceStats{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		private IntPtr objPtr; // opaque VidyoNetworkInterfaceStats reference.
		public IntPtr GetObjectPtr(){
			return objPtr;
		}
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern Boolean VidyoNetworkInterfaceStatsGetisUpNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoNetworkInterfaceStatsGetnameNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoNetworkInterfaceStatsGettypeNative(IntPtr obj);

		public Boolean isUp;
		public String name;
		public String type;
		public NetworkInterfaceStats(IntPtr obj){
			objPtr = obj;

			isUp = VidyoNetworkInterfaceStatsGetisUpNative(objPtr);
			name = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoNetworkInterfaceStatsGetnameNative(objPtr));
			type = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoNetworkInterfaceStatsGettypeNative(objPtr));
		}
	};
}
