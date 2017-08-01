$(document).ready(function () {
    $("#register").click(function () {
         event.preventDefault();       
        url = $(this).parent().parent().attr('action');
      
        username = $("#reg_username").val();
        email = $("#reg_email").val();
        password = $("#reg_password").val();
       
        $.ajax({
            url: url,
            type: "POST",
            data: {
                username: username,
                email: email,
                password:password
            },
            success: function (result) {         
                $(':input').val('');
                $("#message").append(
                      "Your registeration has been sent successfully"
                    );
            }
        });
       
    })
    $("#login").click(function () {
        event.preventDefault();

        username = $("#log_username").val();
        password = $("#log_password").val();
        console.log(username + " " + password);

        url = $(this).parent().parent().attr('action');

        $.ajax({
            url: url,
            type: "POST",
            data: {
                username: username,           
                password: password
            },
            error:function(){
                console.log("error");
            },
            success: function (result) {
                $(':input').val('');
                console.log("sucees");
              //  location.reload();
            }
        });
    });

    $.validate({
        modules: 'location, date, security, file'
       
    });

})
