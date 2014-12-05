$(function () {

    var customerHub = $.connection.customerHub;


    customerHub.client.addNewMessageToPage = function (message) {
        //Add name and message to the page here
        console.log(message);
        $('#messages').append('<li>'+ message + '</li>');
    };
    

    customerHub.client.updateCustomerList = function (customers) {
        console.log(customers);
    }

    $.connection.hub.start();


    //$.connection.hub.start().done(function () {
    //    console.log('connected to Hub');
    //    // call server SendMessage method

    //});


   


});