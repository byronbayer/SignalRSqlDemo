

$(function() {

    // Proxy created on the fly
    var job = $.connection.jobHub;

    // Declare a function on the job hub so the server can invoke it
    job.client.displayStatus = function() {
        getData();
    };

    // Start the connection
    $.connection.hub.start();
    getData();
});

function getData() {
    var $tbl = $('#tblJobInfo');
    $.ajax({
        url: '../api/Values/GetValues',
        type: 'GET',
        datatype: 'json',
        success: function(data) {
            if (data.length > 0) {
                $tbl.empty();
                $tbl.append(' <tr><th>ID</th><th>Name</th><th>Status</th></tr>');
                var rows = [];
                for (var i = 0; i < data.length; i++) {
                    rows.push(' <tr><td>' + data[i].JobId + '</td><td>' + data[i].Name + '</td><td>' + data[i].Status + '</td></tr>');
                }
                $tbl.append(rows.join(''));
            }
        }
    });
}