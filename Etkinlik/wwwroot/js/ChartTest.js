function dataRender(jinfo) {
    var label = [];
    var data = [];
    var color = [];

    for (var i in jinfo) {
        label.push(jinfo[i].choiceName);
        data.push(jinfo[i].vote);
        color.push(randomColorString());
    }
    renderChart(label, data, color);
}

function randomColorString() {
    var color = 'rgba(' + randomNumber(0, 255) + ', ' + randomNumber(0, 255) + ', ' + randomNumber(0, 255) + ', 1)';
    return color;
}

function randomNumber(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min)
}

function renderChart(alabel, adata, abgColor) {
    $('#myChart').remove(); // this is my <canvas> element
    $('#canvasDiv').append('<canvas id="myChart"><canvas>');
    var ctx = document.getElementById("myChart").getContext('2d');
    var mychart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: alabel,
            datasets: [{
                label: 'Oy Sayısı',
                data: adata,
                backgroundColor: abgColor,
                borderColor: abgColor,
                borderWidth: 0.6
            }]
        }, options: {
            legend: {
                display: false
            }
        }
    });
}