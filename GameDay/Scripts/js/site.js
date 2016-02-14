// Write your Javascript code.
$(document).ready(function () {
    $('.dragme').draggable({ helper: 'clone' });
})

function addPlayerField() {
    $('#playerField').removeClass('hidden');
}

$('#playerName').on('click keypress', function (e) {
    if (e.keyCode == '13') {
        if ($(this).val() != null || !this.val().Equals("")) {
            var newDiv1 = $("<div class='table-bordered panel-heading text-center names-text dragme player'/>");
            var newDiv2 = $("div");
            var player = $(this).val();
            $('#playerList').append('<div class="table-bordered panel-heading text-center names-text dragme player">' + player + '</div>');
            $('#playerField').addClass('hidden');
            $('#playerName').val("");
        }
        else {
            return window.alert("Please enter a name");
        }
    }
    return;
});

function removePlayer() {

}

function addNewEvent() {
    var event = $('div[id^="title"]:last');
    var num = parseInt(event.prop("id").match(/\d+/g), 10) + 1;
    var clone = event.clone().prop('id', 'title0');
    clone.find('a').add('data-target', '#details' + num);
    clone.find('a').add('href', '#details' + num);
    clone.find('#details0').add('id', '#details' + num);
    clone.removeClass('hidden');
    $('#eventContainer').append(clone);
}

$(function () {
    // Declare a proxy to reference the hub.
    var chat = $.connection.chatHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Enter your name:', ''));
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});