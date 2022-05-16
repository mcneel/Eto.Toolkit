//
// Auto-generated from generator.cs, do not edit
//
// We keep references to objects, so warning 414 is expected

#pragma warning disable 414

using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using QTKit;
using Metal;
using CoreML;
using OpenGL;
using AppKit;
using Photos;
using ModelIO;
using Network;
using SceneKit;
using Contacts;
using Security;
using CloudKit;
using AudioUnit;
using CoreVideo;
using CoreMedia;
using CoreImage;
using SpriteKit;
using Foundation;
using ObjCRuntime;
using MediaPlayer;
using GameplayKit;
using CoreGraphics;
using CoreLocation;
using AVFoundation;
using FileProvider;
using CoreAnimation;
using CoreFoundation;
using NetworkExtension;

#nullable enable

namespace ScintillaNET {
	[Protocol (Name = "ScintillaNotificationProtocol", WrapperType = typeof (ScintillaNotificationProtocolWrapper))]
	[ProtocolMember (IsRequired = true, IsProperty = false, IsStatic = false, Name = "Notification", Selector = "notification:", ParameterType = new Type [] { typeof (IntPtr) }, ParameterByRef = new bool [] { false })]
	public partial interface IScintillaNotificationProtocol : INativeObject, IDisposable
	{
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[Export ("notification:")]
		[Preserve (Conditional = true)]
		void Notification (global::System.IntPtr notification);
		
	}
	
	internal sealed class ScintillaNotificationProtocolWrapper : BaseWrapper, IScintillaNotificationProtocol {
		[Preserve (Conditional = true)]
		public ScintillaNotificationProtocolWrapper (IntPtr handle, bool owns)
			: base (handle, owns)
		{
		}
		
		[Export ("notification:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public void Notification (global::System.IntPtr notification)
		{
			if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
				global::Scintilla.XamMac2.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("notification:"), notification);
			} else {
				global::Scintilla.XamMac2.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("notification:"), notification);
			}
		}
		
	}
}
namespace ScintillaNET {
	[Protocol()]
	[Register("ScintillaNotificationProtocol", false)]
	[Model]
	public unsafe abstract partial class ScintillaNotificationProtocol : NSObject, IScintillaNotificationProtocol {
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		protected ScintillaNotificationProtocol () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = false;
			InitializeHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
		}

		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected ScintillaNotificationProtocol (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = false;
		}

		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal ScintillaNotificationProtocol (IntPtr handle) : base (handle)
		{
			IsDirectBinding = false;
		}

		[Export ("notification:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public abstract void Notification (global::System.IntPtr notification);
	} /* class ScintillaNotificationProtocol */
}
