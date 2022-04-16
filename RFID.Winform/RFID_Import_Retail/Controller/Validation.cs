using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.Controller
{
    class Validation
    {
        // Empty and valid char
        public class ValueEmpty_Contain : ConditionValidationRule
        {
            public ValueEmpty_Contain()
            {
                this.ConditionOperator = ConditionOperator.Contains;
                this.ErrorType = ErrorType.Critical;
            }
            public override bool Validate(System.Windows.Forms.Control control, object value)
            {
                int flag = 0;
                var content = (control as DevExpress.XtraEditors.TextEdit).Text;
                if (ValidationHelper.Validate(value, ConditionOperator.IsBlank, null, null, null))
                {
                    flag = 1;
                }
                else
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(content, @"^[a-zA-Z0-9]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        flag = 2;
                    }
                }
                switch (flag)
                {
                    case 1:
                        this.ErrorText = "Trường bắt buộc nhập";
                        return false;
                    case 2:
                        this.ErrorText = "Có ký tự không cho phép";
                        return false;
                    default: break;
                }
                return true;
            }
        }

        //Valid and don't have unicode
        // Empty and valid char
        public class Value_Contain : ConditionValidationRule
        {
            public Value_Contain()
            {
                this.ConditionOperator = ConditionOperator.Contains;
                this.ErrorType = ErrorType.Critical;
            }
            public override bool Validate(System.Windows.Forms.Control control, object value)
            {
                int flag = 0;
                var content = (control as DevExpress.XtraEditors.TextEdit).Text;

                if (!System.Text.RegularExpressions.Regex.IsMatch(content, @"^[a-zA-Z0-9]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    flag = 1;
                }

                switch (flag)
                {
                    case 1:
                        this.ErrorText = "Có ký tự không cho phép";
                        return false;
                    default: break;
                }
                return true;
            }
        }
        // Empty
        public class Empty_Contain : ConditionValidationRule
        {
            public Empty_Contain()
            {
                this.ConditionOperator = ConditionOperator.Contains;
                this.ErrorType = ErrorType.Critical;
            }
            public override bool Validate(System.Windows.Forms.Control control, object value)
            {
                int flag = 0;
                var content = (control as DevExpress.XtraEditors.TextEdit).Text;
                if (ValidationHelper.Validate(value, ConditionOperator.IsBlank, null, null, null))
                {
                    flag = 1;
                }
                switch (flag)
                {
                    case 1:
                        this.ErrorText = "Trường bắt buộc nhập";
                        return false;
                    default: break;
                }
                return true;
            }
        }
        // invalid char
        public class Valid_Contain : ConditionValidationRule
        {
            public Valid_Contain()
            {
                this.ConditionOperator = ConditionOperator.Contains;
                this.ErrorType = ErrorType.Critical;
            }
            public override bool Validate(System.Windows.Forms.Control control, object value)
            {
                int flag = 0;
                var content = (control as DevExpress.XtraEditors.TextEdit).Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(content, @"[\*\%\/\\\&\?\,\'\;\:\!\-\""\<\>]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    flag = 1;
                }
                switch (flag)
                {
                    case 1:
                        this.ErrorText = "Có ký tự không cho phép";
                        return false;
                    default: break;
                }
                return true;
            }
        }

        // Empty and invalid char
        public class ValidEmpty_Contain : ConditionValidationRule
        {
            public ValidEmpty_Contain()
            {
                this.ConditionOperator = ConditionOperator.Contains;
                this.ErrorType = ErrorType.Critical;
            }
            public override bool Validate(System.Windows.Forms.Control control, object value)
            {
                int flag = 0;
                var content = (control as DevExpress.XtraEditors.TextEdit).Text;
                if (ValidationHelper.Validate(value, ConditionOperator.IsBlank, null, null, null))
                {
                    flag = 1;
                }
                else
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(content, @"[\%\/\\\&\?\,\'\;\:\!\-\""\<\>]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        flag = 2;
                    }
                }
                switch (flag)
                {
                    case 1:
                        this.ErrorText = "Trường bắt buộc nhập";
                        return false;
                    case 2:
                        this.ErrorText = "Có ký tự không cho phép";
                        return false;
                    default: break;
                }
                return true;
            }
        }
    }
}
