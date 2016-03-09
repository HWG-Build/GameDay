//----------------------------SignalR Chathub---------------------------------//
$(function () {
    $.connection.hub.logging = true;
    var chat = $.connection.chatHub;
    chat.client.broadcastMessage = function (name, message) {
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    $('#message').focus();
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            chat.server.send($('#message').val());
            $('#message').val('').focus();
        });
    });
});
////// 
//# sourceMappingURL=chatroom.js.map