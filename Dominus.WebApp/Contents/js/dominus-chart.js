window.$dominusChart = {

    filterData: function (array, prop, val) {
        try {
            return array.filter(function (el) { return el[prop] == val });
        } catch (e) {
            console.log(e);
        }
    },

    groupData: function (array, prop, val) {
        try {
            return array.reduce(function (result, obj) {
                result[obj[prop]] = result[obj[prop]] || 0;
                result[obj[prop]] += obj[val];
                return result;
            }, Object.create(null));
        } catch (e) {
            console.log(e);
        }
    },

    calcTotal: function (array, val) {
        try {
            return array.reduce(function (result, el) { result += el[val]; return result; }, 0);
        } catch (e) {
            console.log(e);
        }
    },

    createBarChart: function (div, title, dataArray, colors) {
        try {
            return new Chart(div.getContext('2d'), {
                type: 'horizontalBar',
                data: {
                    labels: Object.keys(dataArray),
                    datasets: [{
                        data: Object.keys(dataArray).map(function (key) { return dataArray[key]; }),
                        backgroundColor: colors
                    }]
                },
                options: {
                    responsiveAnimationDuration: 1000,
                    maintainAspectRatio: false,
                    title: {
                        display: true,
                        fontColor: 'black',
                        text: title
                    },
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [{
                            ticks: {
                                beginAtZero: true
                            },
                            display: false
                        }],
                        yAxes: [{
                            display: false
                        }]
                    },
                    tooltips: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return tooltipItem.xLabel.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
                            }
                        }
                    },
                    animation: {
                        onProgress: function () {
                            var ctx = this.chart.ctx;

                            this.data.datasets.forEach(function (dataset) {
                                for (var i = 0; i < dataset.data.length; i++) {
                                    var model = dataset._meta[Object.keys(dataset._meta)[0]].data[i]._model;
                                    var value = model.label + ": " + dataset.data[i].toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
                                    ctx.fillText(value, model.base + 15, model.y + 8);
                                }
                            });
                        }
                    }
                }
            });
        } catch (e) {
            console.log(e);
        }
    },

    createColumnChart: function (div, title, dataArray, colors) {
        try {
            return new Chart(div.getContext('2d'), {
                type: 'bar',
                data: {
                    labels: Object.keys(dataArray),
                    datasets: [{
                        data: Object.keys(dataArray).map(function (key) { return dataArray[key]; }),
                        backgroundColor: colors
                    }]
                },
                options: {
                    responsiveAnimationDuration: 1000,
                    maintainAspectRatio: false,
                    title: {
                        display: true,
                        fontColor: 'black',
                        text: title
                    },
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [{
                            display: true
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            },
                            display: false
                        }]
                    },
                    tooltips: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return tooltipItem.yLabel.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
                            }
                        }
                    }
                }
            });
        } catch (e) {
            console.log(e);
        }
    },

    createPieChart: function (div, title, dataArray, colors, showLegend) {
        try {
            return new Chart(div.getContext('2d'), {
                type: 'pie',
                data: {
                    labels: Object.keys(dataArray),
                    datasets: [{
                        data: Object.keys(dataArray).map(function (key) { return dataArray[key]; }),
                        backgroundColor: colors
                    }]
                },
                options: {
                    responsiveAnimationDuration: 1000,
                    maintainAspectRatio: false,
                    title: {
                        display: true,
                        fontColor: 'black',
                        text: title
                    },
                    legend: {
                        display: showLegend || false,
                        position: 'right'
                    },
                    tooltips: {
                        callbacks: {
                            label: function (tooltipItem, data) {
                                var label = data.labels[tooltipItem.index];
                                var value = data.datasets[0].data[tooltipItem.index];
                                return label + ' ' + value.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
                            }
                        }
                    }
                }
            });
        } catch (e) {
            console.log(e);
        }
    }
};
