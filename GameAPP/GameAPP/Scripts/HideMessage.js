function hideMessage(event) {
    var message = document.getElementById('message');
    if (message != null)
        message.parentNode.removeChild(message);
}