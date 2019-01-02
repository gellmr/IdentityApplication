(function () {

  var checkoutSubmit = function (event, xhr, status) {
    var message = xhr.getResponseHeader('message');
    if (message != null) {
      console.log(message);
    }
    switch (xhr.statusText) {

      case "Created":
        var userId = xhr.getResponseHeader('userId');
        var orderId = xhr.getResponseHeader('orderId');
        console.log("userId: " + userId);
        console.log("orderId: " + orderId);
        // redirect self...
        window.location.href = '/customer/' + userId + '/order/' + orderId;
        break;
    }
  };

  var checkoutError = function (event, xhr, status, errors) {
    switch (xhr.status) {

      case 401: // Unauthorized
        window.location.href = '/login'; // redirect to login page
        break;

      case 400: // Bad Request
        var userId = xhr.responseJSON['userId'];
        var redirect = xhr.responseJSON['redirect'];
        if (redirect != undefined) {
          window.location.href = redirect;
        }
        break;

      case 500: // Internal Server Error
        console.log("There was a server error!")
        var errorDiv = $('#serverError');
        errorDiv.html(xhr.statusText);
        errorDiv.show();
        break;
    }
  };

  jQuery(document).ready(function ($) {
    $(document).on('ajax:complete', '#checkoutForm', checkoutSubmit
    ).on('ajax:error', '#checkoutForm', checkoutError
    );
  });

})();
