(function () {
    'use strict'
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    //Array.prototype.slice.call(forms)
    //    .forEach(function (form) {
    //        form.addEventListener('submit', function (event) {
    //            if (!form.checkValidity()) {
    //                event.preventDefault()
    //                event.stopPropagation()
    //            }
    //            form.classList.add('was-validated')
    //        }, false)
    //    })
})()

function fnOpenNotificationDRP() {
    //var urlGetNotification = '@Url.Action("GetNotificationCount", "Notification")';
    //var urlGetNotification = '~/Admin/Notification/GetNotificationCount';
    //alert('fnOpenNotificationDRP open by click--');
    //$("#notificationLists").load(window.location.href + " #notificationLists");
    var div = document.getElementById("notificationLists");
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
    //alert('fnOpenNotificationDRP open by click site.js--');
    $.ajax({
        url: '/Notification/GetNotificationCount',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            //alert('success== ' + data.count);
            $.each(data.count, function (i, item) {
                let notificationMassage = '';
                notificationMassage = '<a class="dropdown-item" href="javascript:;" onclick="fnViewOneNotificationOnly(' + item.notificationID + ')"><div class="d-flex align-items-center">' + item.notificationText + '</div></a>';
                document.getElementById('notificationLists').innerHTML += notificationMassage;
            });
        }
    });
};

function fnOpenReminderDRP() {
    //var urlGetReminder = '@Url.Action("GetReminderCount", "Notification")';
    //alert('fnOpenReminderDRP open by click--');
    //$("#reminderLists").load(window.location.href + " #reminderLists");
    //debugger;
    var div = document.getElementById("reminderLists");
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
    //debugger;
    //alert('fnOpenReminderDRP open by click site.js--');
    $.ajax({
        url: '/Notification/GetReminderCount',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
           // alert(data);
            $.each(data.count, function (i, item1) {
                let reminderMassage = '';
                reminderMassage = '<a class="dropdown-item" href="javascript:;" onclick="fnViewOneReminderOnly(' + item1.reminderID + ')"><div class="d-flex align-items-center">' + item1.reminderText + '</div></a>';
                document.getElementById('reminderLists').innerHTML += reminderMassage;
            });
        }
    });
};
