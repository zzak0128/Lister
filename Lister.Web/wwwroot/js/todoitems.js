var token = $('input:hidden[name="__RequestVerificationToken"]').val();

function deleteToDo(id) {
    $.ajax({
        type: "POST",
        url: window.location + '?handler=delete',
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

function updateState(id) {
    var selectList = document.getElementById('select_' + id);
    var newState = selectList.value;

    $.ajax({
        type: "POST",
        url: window.location + '?handler=UpdateStatus',
        contenttype: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { id: id, state: newState},
        headers: {
            RequestVerificationToken: token
        },
        success: function (view) {
            $('#todotable').html(view);
        }
    });
}