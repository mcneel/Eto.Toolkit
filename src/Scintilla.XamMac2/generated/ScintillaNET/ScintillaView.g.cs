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
	[Register("ScintillaView", true)]
	public unsafe partial class ScintillaView : global::AppKit.NSView {
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selDelegate = "delegate";
		static readonly IntPtr selDelegateHandle = Selector.GetHandle ("delegate");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selGetColorProperty_Parameter_ = "getColorProperty:parameter:";
		static readonly IntPtr selGetColorProperty_Parameter_Handle = Selector.GetHandle ("getColorProperty:parameter:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selGetGeneralProperty_ = "getGeneralProperty:";
		static readonly IntPtr selGetGeneralProperty_Handle = Selector.GetHandle ("getGeneralProperty:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selGetGeneralProperty_Parameter_ = "getGeneralProperty:parameter:";
		static readonly IntPtr selGetGeneralProperty_Parameter_Handle = Selector.GetHandle ("getGeneralProperty:parameter:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selGetGeneralProperty_Parameter_Extra_ = "getGeneralProperty:parameter:extra:";
		static readonly IntPtr selGetGeneralProperty_Parameter_Extra_Handle = Selector.GetHandle ("getGeneralProperty:parameter:extra:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selGetStringProperty_Parameter_ = "getStringProperty:parameter:";
		static readonly IntPtr selGetStringProperty_Parameter_Handle = Selector.GetHandle ("getStringProperty:parameter:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selMessage_WParam_LParam_ = "message:wParam:lParam:";
		static readonly IntPtr selMessage_WParam_LParam_Handle = Selector.GetHandle ("message:wParam:lParam:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selScrollView = "scrollView";
		static readonly IntPtr selScrollViewHandle = Selector.GetHandle ("scrollView");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetColorProperty_Parameter_FromHTML_ = "setColorProperty:parameter:fromHTML:";
		static readonly IntPtr selSetColorProperty_Parameter_FromHTML_Handle = Selector.GetHandle ("setColorProperty:parameter:fromHTML:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetColorProperty_Parameter_Value_ = "setColorProperty:parameter:value:";
		static readonly IntPtr selSetColorProperty_Parameter_Value_Handle = Selector.GetHandle ("setColorProperty:parameter:value:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetDelegate_ = "setDelegate:";
		static readonly IntPtr selSetDelegate_Handle = Selector.GetHandle ("setDelegate:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetGeneralProperty_Parameter_Value_ = "setGeneralProperty:parameter:value:";
		static readonly IntPtr selSetGeneralProperty_Parameter_Value_Handle = Selector.GetHandle ("setGeneralProperty:parameter:value:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetGeneralProperty_Value_ = "setGeneralProperty:value:";
		static readonly IntPtr selSetGeneralProperty_Value_Handle = Selector.GetHandle ("setGeneralProperty:value:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetReferenceProperty_Parameter_Value_ = "setReferenceProperty:parameter:value:";
		static readonly IntPtr selSetReferenceProperty_Parameter_Value_Handle = Selector.GetHandle ("setReferenceProperty:parameter:value:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetString_ = "setString:";
		static readonly IntPtr selSetString_Handle = Selector.GetHandle ("setString:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selSetStringProperty_Parameter_Value_ = "setStringProperty:parameter:value:";
		static readonly IntPtr selSetStringProperty_Parameter_Value_Handle = Selector.GetHandle ("setStringProperty:parameter:value:");
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		const string selString = "string";
		static readonly IntPtr selStringHandle = Selector.GetHandle ("string");
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		static readonly IntPtr class_ptr = Class.GetHandle ("ScintillaView");
		
		public override IntPtr ClassHandle { get { return class_ptr; } }
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		public ScintillaView () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::Scintilla.XamMac2.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
			} else {
				InitializeHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
			}
		}

		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[DesignatedInitializer]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("initWithCoder:")]
		public ScintillaView (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::Scintilla.XamMac2.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("initWithCoder:"), coder.Handle), "initWithCoder:");
			} else {
				InitializeHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("initWithCoder:"), coder.Handle), "initWithCoder:");
			}
		}

		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected ScintillaView (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = GetType ().Assembly == global::Scintilla.XamMac2.Messaging.this_assembly;
		}

		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal ScintillaView (IntPtr handle) : base (handle)
		{
			IsDirectBinding = GetType ().Assembly == global::Scintilla.XamMac2.Messaging.this_assembly;
		}

		[Export ("getColorProperty:parameter:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual global::AppKit.NSColor GetColorProperty (int property, nint parameter)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return  Runtime.GetNSObject<global::AppKit.NSColor> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_int_nint (this.Handle, selGetColorProperty_Parameter_Handle, property, parameter));
				} else {
					return  Runtime.GetNSObject<global::AppKit.NSColor> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_int_nint (this.Handle, selGetColorProperty_Parameter_Handle, property, parameter));
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return  Runtime.GetNSObject<global::AppKit.NSColor> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_int_nint (this.SuperHandle, selGetColorProperty_Parameter_Handle, property, parameter));
				} else {
					return  Runtime.GetNSObject<global::AppKit.NSColor> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_int_nint (this.SuperHandle, selGetColorProperty_Parameter_Handle, property, parameter));
				}
			}
		}
		
		[Export ("getGeneralProperty:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual nint GetGeneralProperty (int property)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSend_int (this.Handle, selGetGeneralProperty_Handle, property);
				} else {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSend_int (this.Handle, selGetGeneralProperty_Handle, property);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSendSuper_int (this.SuperHandle, selGetGeneralProperty_Handle, property);
				} else {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSendSuper_int (this.SuperHandle, selGetGeneralProperty_Handle, property);
				}
			}
		}
		
		[Export ("getGeneralProperty:parameter:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual nint GetGeneralProperty (int property, nint parameter)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSend_int_nint (this.Handle, selGetGeneralProperty_Parameter_Handle, property, parameter);
				} else {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSend_int_nint (this.Handle, selGetGeneralProperty_Parameter_Handle, property, parameter);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSendSuper_int_nint (this.SuperHandle, selGetGeneralProperty_Parameter_Handle, property, parameter);
				} else {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSendSuper_int_nint (this.SuperHandle, selGetGeneralProperty_Parameter_Handle, property, parameter);
				}
			}
		}
		
		[Export ("getGeneralProperty:parameter:extra:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual nint GetGeneralProperty (int property, nint parameter, nint extra)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSend_int_nint_nint (this.Handle, selGetGeneralProperty_Parameter_Extra_Handle, property, parameter, extra);
				} else {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSend_int_nint_nint (this.Handle, selGetGeneralProperty_Parameter_Extra_Handle, property, parameter, extra);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSendSuper_int_nint_nint (this.SuperHandle, selGetGeneralProperty_Parameter_Extra_Handle, property, parameter, extra);
				} else {
					return global::Scintilla.XamMac2.Messaging.nint_objc_msgSendSuper_int_nint_nint (this.SuperHandle, selGetGeneralProperty_Parameter_Extra_Handle, property, parameter, extra);
				}
			}
		}
		
		[Export ("getStringProperty:parameter:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual string GetStringProperty (int property, nint parameter)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_int_nint (this.Handle, selGetStringProperty_Parameter_Handle, property, parameter));
				} else {
					return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_int_nint (this.Handle, selGetStringProperty_Parameter_Handle, property, parameter));
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_int_nint (this.SuperHandle, selGetStringProperty_Parameter_Handle, property, parameter));
				} else {
					return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_int_nint (this.SuperHandle, selGetStringProperty_Parameter_Handle, property, parameter));
				}
			}
		}
		
		[Export ("message:wParam:lParam:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual global::System.IntPtr Message (uint message, global::System.IntPtr wParam, global::System.IntPtr lParam)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_UInt32_IntPtr_IntPtr (this.Handle, selMessage_WParam_LParam_Handle, message, wParam, lParam);
				} else {
					return global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend_UInt32_IntPtr_IntPtr (this.Handle, selMessage_WParam_LParam_Handle, message, wParam, lParam);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					return global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_UInt32_IntPtr_IntPtr (this.SuperHandle, selMessage_WParam_LParam_Handle, message, wParam, lParam);
				} else {
					return global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper_UInt32_IntPtr_IntPtr (this.SuperHandle, selMessage_WParam_LParam_Handle, message, wParam, lParam);
				}
			}
		}
		
		[Export ("setColorProperty:parameter:value:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual void SetColorProperty (int property, nint parameter, global::AppKit.NSColor value)
		{
			var value__handle__ = value.GetNonNullHandle (nameof (value));
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetColorProperty_Parameter_Value_Handle, property, parameter, value__handle__);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetColorProperty_Parameter_Value_Handle, property, parameter, value__handle__);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetColorProperty_Parameter_Value_Handle, property, parameter, value__handle__);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetColorProperty_Parameter_Value_Handle, property, parameter, value__handle__);
				}
			}
		}
		
		[Export ("setColorProperty:parameter:fromHTML:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual void SetColorProperty (int property, nint parameter, string fromHTML)
		{
			if (fromHTML == null)
				ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (fromHTML));
			var nsfromHTML = NSString.CreateNative (fromHTML);
			
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetColorProperty_Parameter_FromHTML_Handle, property, parameter, nsfromHTML);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetColorProperty_Parameter_FromHTML_Handle, property, parameter, nsfromHTML);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetColorProperty_Parameter_FromHTML_Handle, property, parameter, nsfromHTML);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetColorProperty_Parameter_FromHTML_Handle, property, parameter, nsfromHTML);
				}
			}
			NSString.ReleaseNative (nsfromHTML);
			
		}
		
		[Export ("setGeneralProperty:parameter:value:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual void SetGeneralProperty (int property, nint parameter, nint value)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_nint (this.Handle, selSetGeneralProperty_Parameter_Value_Handle, property, parameter, value);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_nint (this.Handle, selSetGeneralProperty_Parameter_Value_Handle, property, parameter, value);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_nint (this.SuperHandle, selSetGeneralProperty_Parameter_Value_Handle, property, parameter, value);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_nint (this.SuperHandle, selSetGeneralProperty_Parameter_Value_Handle, property, parameter, value);
				}
			}
		}
		
		[Export ("setGeneralProperty:value:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual void SetGeneralProperty (int property, nint value)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint (this.Handle, selSetGeneralProperty_Value_Handle, property, value);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint (this.Handle, selSetGeneralProperty_Value_Handle, property, value);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint (this.SuperHandle, selSetGeneralProperty_Value_Handle, property, value);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint (this.SuperHandle, selSetGeneralProperty_Value_Handle, property, value);
				}
			}
		}
		
		[Export ("setReferenceProperty:parameter:value:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual void SetReferenceProperty (int property, nint parameter, global::System.IntPtr value)
		{
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetReferenceProperty_Parameter_Value_Handle, property, parameter, value);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetReferenceProperty_Parameter_Value_Handle, property, parameter, value);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetReferenceProperty_Parameter_Value_Handle, property, parameter, value);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetReferenceProperty_Parameter_Value_Handle, property, parameter, value);
				}
			}
		}
		
		[Export ("setStringProperty:parameter:value:")]
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual void SetStringProperty (int property, nint parameter, string value)
		{
			if (value == null)
				ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (value));
			var nsvalue = NSString.CreateNative (value);
			
			if (IsDirectBinding) {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetStringProperty_Parameter_Value_Handle, property, parameter, nsvalue);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSend_int_nint_IntPtr (this.Handle, selSetStringProperty_Parameter_Value_Handle, property, parameter, nsvalue);
				}
			} else {
				if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetStringProperty_Parameter_Value_Handle, property, parameter, nsvalue);
				} else {
					global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_int_nint_IntPtr (this.SuperHandle, selSetStringProperty_Parameter_Value_Handle, property, parameter, nsvalue);
				}
			}
			NSString.ReleaseNative (nsvalue);
			
		}
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual global::AppKit.NSScrollView ScrollView {
			[Export ("scrollView")]
			get {
				global::AppKit.NSScrollView ret;
				if (IsDirectBinding) {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						ret =  Runtime.GetNSObject<global::AppKit.NSScrollView> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, selScrollViewHandle));
					} else {
						ret =  Runtime.GetNSObject<global::AppKit.NSScrollView> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, selScrollViewHandle));
					}
				} else {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						ret =  Runtime.GetNSObject<global::AppKit.NSScrollView> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selScrollViewHandle));
					} else {
						ret =  Runtime.GetNSObject<global::AppKit.NSScrollView> (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selScrollViewHandle));
					}
				}
				return ret!;
			}
			
		}
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual string Text {
			[Export ("string")]
			get {
				if (IsDirectBinding) {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, selStringHandle));
					} else {
						return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, selStringHandle));
					}
				} else {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selStringHandle));
					} else {
						return NSString.FromHandle (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selStringHandle));
					}
				}
			}
			
			[Export ("setString:")]
			set {
				if (value == null)
					ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (value));
				var nsvalue = NSString.CreateNative (value);
				
				if (IsDirectBinding) {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetString_Handle, nsvalue);
					} else {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetString_Handle, nsvalue);
					}
				} else {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetString_Handle, nsvalue);
					} else {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetString_Handle, nsvalue);
					}
				}
				NSString.ReleaseNative (nsvalue);
				
			}
		}
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		object? __mt_WeakDelegate_var;
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		public virtual NSObject? WeakDelegate {
			[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
			get {
				NSObject ret;
				if (IsDirectBinding) {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						ret = Runtime.GetNSObject (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, selDelegateHandle));
					} else {
						ret = Runtime.GetNSObject (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSend (this.Handle, selDelegateHandle));
					}
				} else {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						ret = Runtime.GetNSObject (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selDelegateHandle));
					} else {
						ret = Runtime.GetNSObject (global::Scintilla.XamMac2.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selDelegateHandle));
					}
				}
				MarkDirty ();
				__mt_WeakDelegate_var = ret;
				return ret!;
			}
			
			[Export ("setDelegate:", ArgumentSemantic.UnsafeUnretained)]
			set {
				var value__handle__ = value.GetHandle ();
				if (IsDirectBinding) {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetDelegate_Handle, value__handle__);
					} else {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetDelegate_Handle, value__handle__);
					}
				} else {
					if (global::ObjCRuntime.Runtime.IsARM64CallingConvention) {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetDelegate_Handle, value__handle__);
					} else {
						global::Scintilla.XamMac2.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetDelegate_Handle, value__handle__);
					}
				}
				MarkDirty ();
				__mt_WeakDelegate_var = value;
			}
		}
		
		[BindingImpl (BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			if (Handle == IntPtr.Zero) {
				__mt_WeakDelegate_var = null;
			}
		}
	} /* class ScintillaView */
}
