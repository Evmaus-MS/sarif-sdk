﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.CodeAnalysis.Sarif.Sdk {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SarifResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SarifResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.CodeAnalysis.Sarif.SarifResources", typeof(SarifResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The check {0} detected a failure..
        /// </summary>
        internal static string AndroidStudioDescriptionUnknown {
            get {
                return ResourceManager.GetString("AndroidStudioDescriptionUnknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Android Studio input for entry point was missing FQNAME or TYPE..
        /// </summary>
        internal static string AndroidStudioEntryPointMissingRequiredData {
            get {
                return ResourceManager.GetString("AndroidStudioEntryPointMissingRequiredData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file name was not present in an Android Studio problem, even though a line number was present..
        /// </summary>
        internal static string AndroidStudioFileMissing {
            get {
                return ResourceManager.GetString("AndroidStudioFileMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Android Studio problem has no identifying location information..
        /// </summary>
        internal static string AndroidStudioHasNoLocationInformation {
            get {
                return ResourceManager.GetString("AndroidStudioHasNoLocationInformation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A &quot;hint&quot; element was missing a value in an Android Studio log..
        /// </summary>
        internal static string AndroidStudioHintElementMissingValue {
            get {
                return ResourceManager.GetString("AndroidStudioHintElementMissingValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected the Hints element to contain only Hint elements, but another element was observed..
        /// </summary>
        internal static string AndroidStudioHintsElementContainedNonHint {
            get {
                return ResourceManager.GetString("AndroidStudioHintsElementContainedNonHint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Possible resolution: {0}.
        /// </summary>
        internal static string AndroidStudioHintStaple {
            get {
                return ResourceManager.GetString("AndroidStudioHintStaple", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected a non-negative line number for Android Studio problem element..
        /// </summary>
        internal static string AndroidStudioInvalidLineNumber {
            get {
                return ResourceManager.GetString("AndroidStudioInvalidLineNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempted to parse a Problem element, but some other data was present..
        /// </summary>
        internal static string AndroidStudioNotProblemElement {
            get {
                return ResourceManager.GetString("AndroidStudioNotProblemElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An AndroidStudio problem could not be created because required &quot;problem class&quot; element was missing..
        /// </summary>
        internal static string AndroidStudioProblemMissingProblemClass {
            get {
                return ResourceManager.GetString("AndroidStudioProblemMissingProblemClass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot write result: ToolInfo not yet written..
        /// </summary>
        internal static string CannotWriteResultToolInfoMissing {
            get {
                return ResourceManager.GetString("CannotWriteResultToolInfoMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CppCheck file did not start with &quot;results/cppcheck&quot; element with version information..
        /// </summary>
        internal static string CppCheckCppCheckElementMissing {
            get {
                return ResourceManager.GetString("CppCheckCppCheckElementMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not parse CppCheck error node; element name was not error..
        /// </summary>
        internal static string CppCheckElementNotError {
            get {
                return ResourceManager.GetString("CppCheckElementNotError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CppCheck file did not contain the errors element in the expected location..
        /// </summary>
        internal static string CppCheckErrorsElementMissing {
            get {
                return ResourceManager.GetString("CppCheckErrorsElementMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not parse CppCheck location node; element name was not &apos;location&apos;..
        /// </summary>
        internal static string CppCheckLocationElementNameIncorrect {
            get {
                return ResourceManager.GetString("CppCheckLocationElementNameIncorrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} line {1}.
        /// </summary>
        internal static string CppCheckLocationFormat {
            get {
                return ResourceManager.GetString("CppCheckLocationFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The `line` attribute for a CppCheck &lt;location&gt; was not set..
        /// </summary>
        internal static string CppCheckLocationMissingLine {
            get {
                return ResourceManager.GetString("CppCheckLocationMissingLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The `file` attribute for a CppCheck &lt;location&gt; was not set..
        /// </summary>
        internal static string CppCheckLocationMissingName {
            get {
                return ResourceManager.GetString("CppCheckLocationMissingName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The `file` value for a CppCheckLocation was empty..
        /// </summary>
        internal static string CppCheckLocationNameEmpty {
            get {
                return ResourceManager.GetString("CppCheckLocationNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The `line` value for a CppCheckLocation must be positive..
        /// </summary>
        internal static string CppCheckLocationNegativeLine {
            get {
                return ResourceManager.GetString("CppCheckLocationNegativeLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A CppCheck entry must have a nonzero number of locations..
        /// </summary>
        internal static string CppCheckMissingLocation {
            get {
                return ResourceManager.GetString("CppCheckMissingLocation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected to find an element named {0}..
        /// </summary>
        internal static string ExpectedElementNamed {
            get {
                return ResourceManager.GetString("ExpectedElementNamed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fortify PathElement has non-positive line start value..
        /// </summary>
        internal static string FortifyBadLineNumber {
            get {
                return ResourceManager.GetString("FortifyBadLineNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fortify failure in {0}..
        /// </summary>
        internal static string FortifyFallbackMessage {
            get {
                return ResourceManager.GetString("FortifyFallbackMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A node did not match the PathElement portion of the Fortify schema..
        /// </summary>
        internal static string FortifyNotValidPathElement {
            get {
                return ResourceManager.GetString("FortifyNotValidPathElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Result did not match the Fortify schema..
        /// </summary>
        internal static string FortifyNotValidResult {
            get {
                return ResourceManager.GetString("FortifyNotValidResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element expected to be located under a different parent element..
        /// </summary>
        internal static string InvalidParentXml {
            get {
                return ResourceManager.GetString("InvalidParentXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more invalid states were detected during serialization. This indicates that logging methods were called in the wrong order: {0}.
        /// </summary>
        internal static string InvalidState {
            get {
                return ResourceManager.GetString("InvalidState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object cannot be serialized until results serialization is completed..
        /// </summary>
        internal static string ResultsSerializationNotComplete {
            get {
                return ResourceManager.GetString("ResultsSerializationNotComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunInfo has already been written. It cannot be written again..
        /// </summary>
        internal static string RunInfoAlreadyWritten {
            get {
                return ResourceManager.GetString("RunInfoAlreadyWritten", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ToolInfo has already been written. It cannot be written again..
        /// </summary>
        internal static string ToolInfoAlreadyWritten {
            get {
                return ResourceManager.GetString("ToolInfoAlreadyWritten", resourceCulture);
            }
        }
    }
}
