﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class UI {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UI() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Server.Resources.UI", typeof(UI).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string UserInterface_Loop_Command__h_for_help {
            get {
                return ResourceManager.GetString("UserInterface_Loop_Command__h_for_help", resourceCulture);
            }
        }
        
        internal static string UserInterface_EvaluateCommand_Menu {
            get {
                return ResourceManager.GetString("UserInterface_EvaluateCommand_Menu", resourceCulture);
            }
        }
        
        internal static string UserInterface_EvaluateCommand_Invalid_input {
            get {
                return ResourceManager.GetString("UserInterface_EvaluateCommand_Invalid_input", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetFormat_Specify_the_format {
            get {
                return ResourceManager.GetString("UserInterface_SetFormat_Specify_the_format", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetFormat_Format_has_been_set {
            get {
                return ResourceManager.GetString("UserInterface_SetFormat_Format_has_been_set", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetTime_Invalid_format {
            get {
                return ResourceManager.GetString("UserInterface_SetTime_Invalid_format", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetTime_This_acction_is_not_enabled_ {
            get {
                return ResourceManager.GetString("UserInterface_SetTime_This_acction_is_not_enabled_", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetTime_Runnig_process_failed_ {
            get {
                return ResourceManager.GetString("UserInterface_SetTime_Runnig_process_failed_", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetTime_Prces_exited_with_failure_ {
            get {
                return ResourceManager.GetString("UserInterface_SetTime_Prces_exited_with_failure_", resourceCulture);
            }
        }
        
        internal static string UserInterface_ValidateInput_Invalid_input {
            get {
                return ResourceManager.GetString("UserInterface_ValidateInput_Invalid_input", resourceCulture);
            }
        }
        
        internal static string UserInterface_SetTime_Please_enter_the_date_you_want_to_set {
            get {
                return ResourceManager.GetString("UserInterface_SetTime_Please_enter_the_date_you_want_to_set", resourceCulture);
            }
        }
        
        internal static string Program_Main_App_failed_to_run_safely {
            get {
                return ResourceManager.GetString("Program_Main_App_failed_to_run_safely", resourceCulture);
            }
        }
    }
}