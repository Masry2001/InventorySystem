﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventorySystem.Utilities {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("InventorySystem.Utilities.ValidationMessages", typeof(ValidationMessages).Assembly);
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
        ///   Looks up a localized string similar to Created Date cannot be After Modified Date..
        /// </summary>
        internal static string Error_CreatedDateAfterModifiedDate {
            get {
                return ResourceManager.GetString("Error_CreatedDateAfterModifiedDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid email address format!.
        /// </summary>
        internal static string Error_InvalidEmail {
            get {
                return ResourceManager.GetString("Error_InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Name Format.
        /// </summary>
        internal static string Error_InvalidName {
            get {
                return ResourceManager.GetString("Error_InvalidName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Phone Number!.
        /// </summary>
        internal static string Error_InvalidPhone {
            get {
                return ResourceManager.GetString("Error_InvalidPhone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter A Valid Salary With 2 Decimals At Most.
        /// </summary>
        internal static string Error_InvalidSalary {
            get {
                return ResourceManager.GetString("Error_InvalidSalary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Modified Date cannot be earlier than Created Date..
        /// </summary>
        internal static string Error_ModifiedDateBeforeCreatedDate {
            get {
                return ResourceManager.GetString("Error_ModifiedDateBeforeCreatedDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This Field Exceeded The Max Limit Of .
        /// </summary>
        internal static string Error_Notes_LengthLimit {
            get {
                return ResourceManager.GetString("Error_Notes_LengthLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field is required!.
        /// </summary>
        internal static string Error_RequiredField {
            get {
                return ResourceManager.GetString("Error_RequiredField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed To Save Data.
        /// </summary>
        internal static string Failed_Save {
            get {
                return ResourceManager.GetString("Failed_Save", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data has been saved successfully..
        /// </summary>
        internal static string Success_Save {
            get {
                return ResourceManager.GetString("Success_Save", resourceCulture);
            }
        }
    }
}
