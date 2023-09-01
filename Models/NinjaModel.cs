#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyValidations.Models;

public class Ninja
{
    //validations
    [Required (ErrorMessage ="Must provide name")]
    [MinLength(2)] 
    public string Name {get;set;} 

    [Required(ErrorMessage ="Must choose Dojo Location")]
    public string Location {get;set;} 

    [Required(ErrorMessage ="Must choose Favorite Language")] 
    public string Language {get;set;}  

    [NoShortComments]
    public string Comment {get;set;} 

}

//If Comment, must be more than 20 Characters:
public class NoShortCommentsAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   if (value!=null)
    {
        if (((string)value).Length < 20)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Comment must be greater than 20 characters");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
        else
        {
            return new ValidationResult("Comment must be greater than 20 characters"); 
        }
    }
}   