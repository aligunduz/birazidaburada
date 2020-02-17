using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.MyExtensions
{
    public class Custom_Helpers_class
    {
        public static IHtmlString Create_DropDown(List<SelectListItem> liste, string fieldName, string LabelName)
        {

            string result = $@"<div class='form-group'>
            <label class='control-label col-md-2' >{LabelName}</label>
            <div class='col-md-10'>
            <select class='form-control input-validation-error' data-val='true'
            data-val-number='The field ProductId must be a number.' 
            data-val-range='{fieldName} must be selected' 
            data-val-range-max='2147483647'
            data-val-range-min='1'
            data-val-required='the {LabelName} field is required,
            id='{fieldName}' name='{fieldName}'
            aria-describedby='ProductId-error' aria-invalid='true'>
            ";
            
            foreach (var item in liste)
            {
                result += $"<option value= {item.Value} > {item.Text}</option>";
            }
            result += $@"
        </select>

            <span class='text-danger field-validation-error'
                data-valmsg-for='{fieldName}' data-valmsg-replace='true'>
                <span id='{fieldName}-error' class=''>
                </span>
            </span>
        </div>
    </div>";
            
            return new HtmlString(result);



        }
    }
}