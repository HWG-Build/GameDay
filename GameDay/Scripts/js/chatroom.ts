declare var $: any;

//----------------------------SignalR Chathub---------------------------------//


$(() => {
    $.connection.hub.logging = true;
    var chat = $.connection.chatHub;
    chat.client.broadcastMessage = (name: string, message: string) => {
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    $('#message').focus();
    $.connection.hub.start().done(() => {
        $('#sendmessage').click(() => {
            chat.server.send($('#message').val());
            $('#message').val('').focus();
        });
    });
});

//////