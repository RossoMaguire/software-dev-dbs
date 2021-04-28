$(document).ready(function () {

    //when the hamburger is clicked then show the mobile menu
    $('#hamburger').click(function () {
            $('#mobile-menu').toggle();
    })

    //triggering the nav to shrink on page scroll
    $(window).scroll(function () {
        if ($(this).scrollTop() > 250) {
            $('header').addClass("sticky-nav-border");
            $('.nav-link-button, .logo').addClass("sticky-nav-shrink");
        }
        else {
            $('header').removeClass("sticky-nav-border");
            $('.nav-link-button, .logo').removeClass("sticky-nav-shrink");
        }
    });

    //function to handle the form submit
    $('#formSubmit').on('click', function (e) {

        //build the form object which each field specified
            const Form = {
                name: $('#contact-form #full-name').val(),
                email: $('#contact-form #email-addr').val(),
                subject: $('#contact-form #subject').val(),
                message: $('#contact-form #message').val().trim(), //use trim here as it is a text field removes whitespace before and after the content
            }

        e.preventDefault(); //prevents the built in form submission functionality
        if (validateForm(Form)) { //if validateForm(Form Object) is true
            window.location.href = window.location.href + "?form=sent"; //add the parameter to the url
            $('#contact-form').hide();
            $('#contact-heading').html('Thank you!');
            $('#sent-message').show();
            console.log(Form); //Log the Form object that was sent to the server
        }
    });

    // checking if the parameter ?form-sent is present on the contact page so that we can reset the form and message sent box back to default if it isnt
    if (window.location.href.indexOf("?form=sent") > -1) {
        $('#contact-form').hide();
        $('#contact-heading').html('Thank you!');
        $('#sent-message').show();
    } else {
        $('#contact-form').show();
        $('#contact-heading').html('Get in touch');
        $('#sent-message').hide();
    };

})


//validates the contact form
function validateForm(form) {

    const errorMsg = $('#error-msg'); //hidden by default in CSS

    if (form.name === null || form.name === "") {
        errorMsg.show();
        errorMsg.html("Please fill out your name");
        return false;
    }

    if (form.email === null || form.email === "") {
        errorMsg.show();
        errorMsg.html("Please fill out a correct email address");
        return false;
    }

    if(!isValidEmail(form.email)) {
        errorMsg.show();
        errorMsg.html("Please fill out a correct email address");
        return false;
    }

    if (form.subject === null || form.subject === "") {
        form.subject = "Query from Bay View B&B Website"
    }

    if (form.message === null || form.message === "") {
        errorMsg.show();
        errorMsg.html("Please fill out a message");
        return false;
    }

    errorMsg.hide();
    errorMsg.html("") //if an error message was shown before this will hide it when all conditions are met

    return true;
}

//validate the email address
function isValidEmail(email) {
  var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
  return regex.test(email);
}