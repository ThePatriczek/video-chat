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
	public class RoomStatsFactory
	{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr VidyoRoomStatsConstructDefaultNative();
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		public static extern void VidyoRoomStatsDestructNative(IntPtr obj);
		public static RoomStats Create()
		{
			IntPtr objPtr = VidyoRoomStatsConstructDefaultNative();
			return new RoomStats(objPtr);
		}
		public static void Destroy(RoomStats obj)
		{
			VidyoRoomStatsDestructNative(obj.GetObjectPtr());
		}
	}
	public class RoomStats{
#if __IOS__
		const string importLib = "__Internal";
#else
		const string importLib = "libVidyoClient";
#endif
		private IntPtr objPtr; // opaque VidyoRoomStats reference.
		public IntPtr GetObjectPtr(){
			return objPtr;
		}
		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetavailableDecodeBwPercentNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetavailableDecodeCpuPercentNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetavailableEncodeBwPercentNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetavailableEncodeCpuPercentNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetbandwidthAppNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetbandwidthAudioNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetbandwidthVideoNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetcallIdNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetconferenceIdNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetcpuUsageNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetcurrentBandwidthDecodePixelRateNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetcurrentBandwidthEncodePixelRateNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetcurrentCpuDecodePixelRateNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetcurrentCpuEncodePixelRateNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetidNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetmaxDecodePixelRateNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetmaxEncodePixelRateNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetmaxVideoSourcesNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetparticipantGenerationStatsNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetparticipantGenerationStatsArrayNative(IntPtr obj, ref int size);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoRoomStatsFreeparticipantGenerationStatsArrayNative(IntPtr obj, int size);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetparticipantStatsNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetparticipantStatsArrayNative(IntPtr obj, ref int size);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoRoomStatsFreeparticipantStatsArrayNative(IntPtr obj, int size);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetrateShaperAppNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetrateShaperAudioNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetrateShaperVideoNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetreceiveBitRateAvailableNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetreceiveBitRateTotalNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGetreflectorIdNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetsendBitRateAvailableNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern ulong VidyoRoomStatsGetsendBitRateTotalNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint VidyoRoomStatsGetstaticSourcesNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGettransportInformationNative(IntPtr obj);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr VidyoRoomStatsGettransportInformationArrayNative(IntPtr obj, ref int size);

		[DllImport(importLib, CallingConvention = CallingConvention.Cdecl)]
		private static extern void VidyoRoomStatsFreetransportInformationArrayNative(IntPtr obj, int size);

		public uint availableDecodeBwPercent;
		public uint availableDecodeCpuPercent;
		public uint availableEncodeBwPercent;
		public uint availableEncodeCpuPercent;
		public BandwidthSummaryStats bandwidthApp;
		public BandwidthSummaryStats bandwidthAudio;
		public BandwidthSummaryStats bandwidthVideo;
		public String callId;
		public String conferenceId;
		public uint cpuUsage;
		public ulong currentBandwidthDecodePixelRate;
		public ulong currentBandwidthEncodePixelRate;
		public ulong currentCpuDecodePixelRate;
		public ulong currentCpuEncodePixelRate;
		public String id;
		public ulong maxDecodePixelRate;
		public ulong maxEncodePixelRate;
		public uint maxVideoSources;
		public List<ParticipantGenerationStats> participantGenerationStats;
		public List<ParticipantStats> participantStats;
		public RateShaperStats rateShaperApp;
		public RateShaperStats rateShaperAudio;
		public RateShaperStats rateShaperVideo;
		public ulong receiveBitRateAvailable;
		public ulong receiveBitRateTotal;
		public String reflectorId;
		public ulong sendBitRateAvailable;
		public ulong sendBitRateTotal;
		public uint staticSources;
		public List<MediaConnectionTransportInfo> transportInformation;
		public RoomStats(IntPtr obj){
			objPtr = obj;

			BandwidthSummaryStats csBandwidthApp = new BandwidthSummaryStats(VidyoRoomStatsGetbandwidthAppNative(objPtr));
			BandwidthSummaryStats csBandwidthAudio = new BandwidthSummaryStats(VidyoRoomStatsGetbandwidthAudioNative(objPtr));
			BandwidthSummaryStats csBandwidthVideo = new BandwidthSummaryStats(VidyoRoomStatsGetbandwidthVideoNative(objPtr));
			List<ParticipantGenerationStats> csParticipantGenerationStats = new List<ParticipantGenerationStats>();
			int nParticipantGenerationStatsSize = 0;
			IntPtr nParticipantGenerationStats = VidyoRoomStatsGetparticipantGenerationStatsArrayNative(VidyoRoomStatsGetparticipantGenerationStatsNative(objPtr), ref nParticipantGenerationStatsSize);
			int nParticipantGenerationStatsIndex = 0;
			while (nParticipantGenerationStatsIndex < nParticipantGenerationStatsSize) {
				ParticipantGenerationStats csTparticipantGenerationStats = new ParticipantGenerationStats(Marshal.ReadIntPtr(nParticipantGenerationStats + (nParticipantGenerationStatsIndex * Marshal.SizeOf(nParticipantGenerationStats))));
				csParticipantGenerationStats.Add(csTparticipantGenerationStats);
				nParticipantGenerationStatsIndex++;
			}

			List<ParticipantStats> csParticipantStats = new List<ParticipantStats>();
			int nParticipantStatsSize = 0;
			IntPtr nParticipantStats = VidyoRoomStatsGetparticipantStatsArrayNative(VidyoRoomStatsGetparticipantStatsNative(objPtr), ref nParticipantStatsSize);
			int nParticipantStatsIndex = 0;
			while (nParticipantStatsIndex < nParticipantStatsSize) {
				ParticipantStats csTparticipantStats = new ParticipantStats(Marshal.ReadIntPtr(nParticipantStats + (nParticipantStatsIndex * Marshal.SizeOf(nParticipantStats))));
				csParticipantStats.Add(csTparticipantStats);
				nParticipantStatsIndex++;
			}

			RateShaperStats csRateShaperApp = new RateShaperStats(VidyoRoomStatsGetrateShaperAppNative(objPtr));
			RateShaperStats csRateShaperAudio = new RateShaperStats(VidyoRoomStatsGetrateShaperAudioNative(objPtr));
			RateShaperStats csRateShaperVideo = new RateShaperStats(VidyoRoomStatsGetrateShaperVideoNative(objPtr));
			List<MediaConnectionTransportInfo> csTransportInformation = new List<MediaConnectionTransportInfo>();
			int nTransportInformationSize = 0;
			IntPtr nTransportInformation = VidyoRoomStatsGettransportInformationArrayNative(VidyoRoomStatsGettransportInformationNative(objPtr), ref nTransportInformationSize);
			int nTransportInformationIndex = 0;
			while (nTransportInformationIndex < nTransportInformationSize) {
				MediaConnectionTransportInfo csTtransportInformation = new MediaConnectionTransportInfo(Marshal.ReadIntPtr(nTransportInformation + (nTransportInformationIndex * Marshal.SizeOf(nTransportInformation))));
				csTransportInformation.Add(csTtransportInformation);
				nTransportInformationIndex++;
			}

			availableDecodeBwPercent = VidyoRoomStatsGetavailableDecodeBwPercentNative(objPtr);
			availableDecodeCpuPercent = VidyoRoomStatsGetavailableDecodeCpuPercentNative(objPtr);
			availableEncodeBwPercent = VidyoRoomStatsGetavailableEncodeBwPercentNative(objPtr);
			availableEncodeCpuPercent = VidyoRoomStatsGetavailableEncodeCpuPercentNative(objPtr);
			bandwidthApp = csBandwidthApp;
			bandwidthAudio = csBandwidthAudio;
			bandwidthVideo = csBandwidthVideo;
			callId = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoRoomStatsGetcallIdNative(objPtr));
			conferenceId = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoRoomStatsGetconferenceIdNative(objPtr));
			cpuUsage = VidyoRoomStatsGetcpuUsageNative(objPtr);
			currentBandwidthDecodePixelRate = VidyoRoomStatsGetcurrentBandwidthDecodePixelRateNative(objPtr);
			currentBandwidthEncodePixelRate = VidyoRoomStatsGetcurrentBandwidthEncodePixelRateNative(objPtr);
			currentCpuDecodePixelRate = VidyoRoomStatsGetcurrentCpuDecodePixelRateNative(objPtr);
			currentCpuEncodePixelRate = VidyoRoomStatsGetcurrentCpuEncodePixelRateNative(objPtr);
			id = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoRoomStatsGetidNative(objPtr));
			maxDecodePixelRate = VidyoRoomStatsGetmaxDecodePixelRateNative(objPtr);
			maxEncodePixelRate = VidyoRoomStatsGetmaxEncodePixelRateNative(objPtr);
			maxVideoSources = VidyoRoomStatsGetmaxVideoSourcesNative(objPtr);
			participantGenerationStats = csParticipantGenerationStats;
			participantStats = csParticipantStats;
			rateShaperApp = csRateShaperApp;
			rateShaperAudio = csRateShaperAudio;
			rateShaperVideo = csRateShaperVideo;
			receiveBitRateAvailable = VidyoRoomStatsGetreceiveBitRateAvailableNative(objPtr);
			receiveBitRateTotal = VidyoRoomStatsGetreceiveBitRateTotalNative(objPtr);
			reflectorId = (string)MarshalPtrToUtf8.GetInstance().MarshalNativeToManaged(VidyoRoomStatsGetreflectorIdNative(objPtr));
			sendBitRateAvailable = VidyoRoomStatsGetsendBitRateAvailableNative(objPtr);
			sendBitRateTotal = VidyoRoomStatsGetsendBitRateTotalNative(objPtr);
			staticSources = VidyoRoomStatsGetstaticSourcesNative(objPtr);
			transportInformation = csTransportInformation;
			VidyoRoomStatsFreetransportInformationArrayNative(nTransportInformation, nTransportInformationSize);
			VidyoRoomStatsFreeparticipantStatsArrayNative(nParticipantStats, nParticipantStatsSize);
			VidyoRoomStatsFreeparticipantGenerationStatsArrayNative(nParticipantGenerationStats, nParticipantGenerationStatsSize);
		}
	};
}
