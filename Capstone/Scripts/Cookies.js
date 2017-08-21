 $(document).ready(function() {

        ReadCookie();

    $( "#RememberMe" ).click(function() {
        WriteCookie();	
        });

    	function WriteCookie(){
                var resultEmail = "Email" + "=" + $("#Email").val();
                resultEmail += "; expires=" + OneWeek();
                resultEmail += "; path = /;";
				document.cookie = resultEmail;
			}
			function ReadCookie(){
                if (document.cookie != null) {
                    var result = document.cookie;
                    var email = result.substr(6)
                    $("#Email").val(email);
                }
        }

            function OneWeek() {
                // from: http://stackoverflow.com/questions/13154552/javascript-set-cookie-with-expire-time
                var when = new Date();
                var time = when.getTime();
                var expireTime = time + 7 * 24 * 60 * 60 * 1000;
                when.setTime(expireTime);
                return when;
            }
});
