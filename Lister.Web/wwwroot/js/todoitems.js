var token = $('input:hidden[name="__RequestVerificationToken"]').val();

function deleteToDo(id) {
    $.ajax({
        type: "POST",
        url: window.location + '?handler=delete', // <-- Where should this point?
        contenttype: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { id: id },
        headers: {
            RequestVerificationToken: token
        },
        success: function (view) {
            $('#todotable').html(view);
        }
    });
}

function updateState(id, state) {
    $.ajax({
        type: "POST",
        url: window.location + '?handler=UpdateStatus', // <-- Where should this point?
        contenttype: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { id: id, state: state},
        headers: {
            RequestVerificationToken: token
        },
        success: function (view) {
            $('#todotable').html(view);
        }
    });
}