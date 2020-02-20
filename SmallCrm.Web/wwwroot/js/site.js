// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function validateVatNumber(vatnumber)
{
    if (!vatnumber || vatnumber.trim().length === 0)
    {
        return false;
    }
 
    let vat = vatnumber.trim();

    if (vat.length !== 9)
    {
        return false;
    }
 
    if (!$.isNumeric(vat))
    {
        return false;
    }
 
    return true;
}

function validateEmail(email)
{

    if (!email || email.trim().length === 0)
    {
        return false;
    }

    if (!email.includes('@'))
    {
        return false;
    }

    if (!email.includes('.'))
    {
        return false;
    }

    return true;
}

let $vatNumberInput = $('.js-VatNumber');
$vatNumberInput.on('input', (evt) => {
    let $vatnumber = $(evt.currentTarget).val();
    let result = validateVatNumber($vatnumber);
    let $validationMessage = $('.js-validation-vatnumber');
    if (result)
    {
        $vatNumberInput.removeClass("is-invalid");
    }

});

let $emailInput = $('.js-Email');
$emailInput.on('input', (evt) => {
    let $email = $(evt.currentTarget).val();
    let result = validateEmail($email);
    let $validationMessage = $('.js-validation-email');
    if (result)
    {
        $emailInput.removeClass("is-invalid");
    }
    alert(result);
});

$.ajax({
    url: "https://localhost:5001/customer/list",
    type: "GET"
}).done((customers) => {
    let $customerList = $('.js-customer-list');
    customers.forEach(element =>
    {
        console.log(element)
    });
})