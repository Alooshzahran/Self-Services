$(document).ready(function () {
    fetch("/TimeAttendance/GetDifferentofTime")
        .then(response => response.json())
        .then(data => {
            // Extract the necessary data for your chart
            const labels = data.map(item => item.label);
            const values = data.map(item => item.value);

            // Create a bar chart using Chart.js
            createBarChart(labels, values);
        })
        .catch(error => console.error('Error fetching data:', error));
    var xValues = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
    var yValues = [7, 7, 8, 8, 7, 7, 8];
    var barColors = ["red", "green", "blue", "orange", "brown","yellow","black"];

    new Chart("myChart", {
        type: "bar",
        data: {
            labels: xValues,
            datasets: [{
                backgroundColor: barColors,
                data: yValues
            }]
        },
        options: {


            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Days of Week'
                    }
                }],

                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Time'
                    },
                    ticks: {
                        beginAtZero: true,

                    }
                }]
            },
            title: {
                    display: true,
                    text: "Time Attendance"
                }
            }
        });
});