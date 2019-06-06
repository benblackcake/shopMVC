url = '/api/dashboardMember/GetChart';
url_customer = '/api/dashboardCustomer/GetDateCustomer';
url_topSale = '/api/dashboardMember/GetTopSale';
url_sum = '/api/dashboardMember/GetSum';

method = 'GET';

var chart_labels = [];
var chart_data = [];

var customer_labels = [];
var customer_data = [];

var topSale_label=[];
var topSale_data=[];

$.ajax({
    url: url,
    method: method,
    success: function (data) {
        chart_labels = data.label;
        chart_data = data.data;
        console.log(chart_data);
        //console.log(defaultData);
        setChart();
    }
});


$.ajax({
    url: url_customer,
    method: method,
    success: function (data) {
        customer_labels = data.label;
        customer_data = data.data;

        //console.log(defaultData);
        setBarChart();
    }
});


$.ajax({
    url: url_topSale,
    method: method,
    success: function (data) {
        topSale_label = data.label;
        topSale_data = data.data;

        //console.log(defaultData);
        setTopBarChart();
    }
});

$.ajax({
    url: url_sum,
    method: method,
    success: function (data) {
        console.log(data.datas[0]);
        $("#sum").text("$"+data.datas[0]);
    }
});

gradientChartOptionsConfigurationWithTooltipPurple = {
    maintainAspectRatio: false,
    legend: {
        display: false
    },

    tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
    },
    responsive: true,
    scales: {
        yAxes: [{
            barPercentage: 1.6,
            gridLines: {
                drawBorder: false,
                color: 'rgba(29,140,248,0.0)',
                zeroLineColor: "transparent",
            },
            ticks: {
                suggestedMin: 60,
                suggestedMax: Math.max.apply(Math, chart_labels),
                padding: 20,
                fontColor: "#9a9a9a"
            }
        }],

        xAxes: [{
            barPercentage: 1.6,
            gridLines: {
                drawBorder: false,
                color: 'rgba(225,78,202,0.1)',
                zeroLineColor: "transparent",
            },
            ticks: {
                padding: 20,
                fontColor: "#9a9a9a"
            }
        }]
    }
};


gradientBarChartConfiguration = {
    maintainAspectRatio: false,
    legend: {
        display: false
    },

    tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
    },
    responsive: true,
    scales: {
        yAxes: [{

            gridLines: {
                drawBorder: false,
                color: 'rgba(29,140,248,0.1)',
                zeroLineColor: "transparent",
            },
            ticks: {
                suggestedMin: 60,
                suggestedMax: Math.max.apply(Math, customer_labels),
                padding: 20,
                fontColor: "#9e9e9e"
            }
        }],

        xAxes: [{

            gridLines: {
                drawBorder: false,
                color: 'rgba(29,140,248,0.1)',
                zeroLineColor: "transparent",
            },
            ticks: {
                padding: 20,
                fontColor: "#9e9e9e"
            }
        }]
    }
};

gradientTopBarChartConfiguration = {
    //maintainAspectRatio: false,
    //legend: {
    //    display: false
    //},

    tooltips: {
        backgroundColor: '#f5f5f5',
        titleFontColor: '#333',
        bodyFontColor: '#666',
        bodySpacing: 4,
        xPadding: 12,
        mode: "nearest",
        intersect: 0,
        position: "nearest"
    },
    responsive: true,
    scales: {
        yAxes: [{

            gridLines: {
                drawBorder: false,
                color: 'rgba(29,140,248,0.1)',
                zeroLineColor: "transparent",
            },
            ticks: {
                suggestedMin: 0,
                suggestedMax: Math.max.apply(Math, topSale_label),
                padding: 20,
                fontColor: "#9e9e9e"
            }
        }],

        xAxes: [{

            gridLines: {
                drawBorder: false,
                color: 'rgba(29,140,248,0.1)',
                zeroLineColor: "transparent",
            },
            ticks: {
                padding: 20,
                fontColor: "#9e9e9e"
            }
        }]
    }
};

function setChart() {
    console.log("enter setChart");
    var ctx = document.getElementById("chartProduct").getContext('2d');

    var gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, 'rgba(72,72,176,0.1)');
    gradientStroke.addColorStop(0.4, 'rgba(72,72,176,0.0)');
    gradientStroke.addColorStop(0, 'rgba(119,52,169,0)'); //purple colors
    var config = {
        type: 'line',
        data: {
            labels: chart_labels,
            datasets: [{
                label: "Monthly sales",
                fill: true,
                backgroundColor: gradientStroke,
                borderColor: '#d346b1',
                borderWidth: 2,
                borderDash: [],
                borderDashOffset: 0.0,
                pointBackgroundColor: '#d346b1',
                pointBorderColor: 'rgba(255,255,255,0)',
                pointHoverBackgroundColor: '#d346b1',
                pointBorderWidth: 20,
                pointHoverRadius: 4,
                pointHoverBorderWidth: 15,
                pointRadius: 4,
                data: chart_data,
            }]
        },
        options: gradientChartOptionsConfigurationWithTooltipPurple
    };
    var myChartData = new Chart(ctx, config);
}



function setBarChart() {
    var ctx = document.getElementById("CustomerChart").getContext("2d");

    var gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, 'rgba(29,140,248,0.2)');
    gradientStroke.addColorStop(0.4, 'rgba(29,140,248,0.0)');
    gradientStroke.addColorStop(0, 'rgba(29,140,248,0)'); //blue colors


    var myChart = new Chart(ctx, {
        type: 'bar',
        responsive: true,
        legend: {
            display: false
        },
        data: {
            labels: customer_labels,
            datasets: [{
                label: "Quantity",
                fill: true,
                backgroundColor: gradientStroke,
                hoverBackgroundColor: gradientStroke,
                borderColor: '#1f8ef1',
                borderWidth: 2,
                borderDash: [],
                borderDashOffset: 0.0,
                data: customer_data,
            }]
        },
        options: gradientBarChartConfiguration
    });
}


function setTopBarChart() {
    var ctx = document.getElementById("TopSaleChart").getContext("2d");

    var gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, 'rgba(29,140,248,0.2)');
    gradientStroke.addColorStop(0.4, 'rgba(29,140,248,0.0)');
    gradientStroke.addColorStop(0, 'rgba(29,140,248,0)'); //blue colors


    var myChart = new Chart(ctx, {
        type: 'bar',
        responsive: true,
        legend: {
            display: false
        },
        data: {
            labels: topSale_label,
            datasets: [{
                label: "Quantity",
                fill: true,
                backgroundColor: gradientStroke,
                hoverBackgroundColor: gradientStroke,
                borderColor: '#1f8ef1',
                borderWidth: 2,
                borderDash: [],
                borderDashOffset: 0.0,
                data: topSale_data,
            }]
        },
        options: gradientTopBarChartConfiguration
    });
}