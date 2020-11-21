window.$dominusChart = {

    filterData: function (array, prop, val) {
        try {
            return array.filter(function (el) { return el[prop] == val });
        } catch (e) {
            console.log(e);
        }
    },

    groupData: function (array, prop, val, optNames) {
        try {
            if (Array.isArray(val)) {
                optNames = optNames || val;
                return array.reduce(function (result, obj) {
                    result[obj[prop]] = result[obj[prop]] || {};
                    for (var i = 0; i < val.length; i++) {
                        result[obj[prop]][optNames[i]] = obj[val[i]];
                    }
                    return result;
                }, Object.create(null));
            }
            else {
                return array.reduce(function (result, obj) {
                    result[obj[prop]] = result[obj[prop]] || 0;
                    result[obj[prop]] += obj[val];
                    return result;
                }, Object.create(null));
            }
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

    createBarChart: function (div, title, dataArray, colors, showLegend) {
        try {
            return new Chart(div.getContext('2d'), {
                type: 'horizontalBar',
                data: {
                    labels: Object.keys(dataArray),
                    datasets: this.generateDataset(Object.keys(dataArray).map(function (key) { return dataArray[key]; }), colors)
                },
                options: {
                    responsiveAnimationDuration: 1000,
                    maintainAspectRatio: false,
                    title: {
                        display: Boolean(title),
                        fontColor: 'black',
                        text: title
                    },
                    legend: {
                        display: showLegend || false,
                        position: 'right'
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
                                    ctx.fillText(value, model.base + 8, model.y + 3);
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

    createColumnChart: function (div, title, dataArray, colors, showLegend) {
        try {
            return new Chart(div.getContext('2d'), {
                type: 'bar',
                data: {
                    labels: Object.keys(dataArray),
                    datasets: this.generateDataset(Object.keys(dataArray).map(function (key) { return dataArray[key]; }), colors)
                },
                options: {
                    responsiveAnimationDuration: 1000,
                    maintainAspectRatio: false,
                    title: {
                        display: Boolean(title),
                        fontColor: 'black',
                        text: title
                    },
                    legend: {
                        display: showLegend || false,
                        position: 'bottom'
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
                    },
                    animation: {
                        onProgress: function () {
                            var chartInstance = this.chart;
                            chartInstance.ctx.textAlign = 'center';
                            chartInstance.ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                            chartInstance.ctx.textBaseline = 'bottom';

                            this.data.datasets.forEach(function (dataset, i) {
                                var meta = chartInstance.controller.getDatasetMeta(i);
                                meta.data.forEach(function (bar, index) {
                                    var value = dataset.data[index];
                                    chartInstance.ctx.fillText(value.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }), bar._model.x, bar._model.y);
                                });
                            });
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
                type: 'doughnut',
                data: {
                    labels: Object.keys(dataArray),
                    datasets: this.generateDataset(Object.keys(dataArray).map(function (key) { return dataArray[key]; }), colors)
                },
                options: {
                    responsiveAnimationDuration: 1000,
                    maintainAspectRatio: false,
                    title: {
                        display: Boolean(title),
                        fontColor: 'black',
                        text: title
                    },
                    legend: {
                        display: showLegend || false,
                        position: 'right',
                        labels: {
                            generateLabels: function (chart) {
                                var data = chart.data;
                                if (data.labels.length && data.datasets.length) {
                                    return data.labels.map(function (label, i) {
                                        var meta = chart.getDatasetMeta(0);
                                        var custom = meta.data[i] && meta.data[i].custom || {};
                                        var value = chart.config.data.datasets[meta.data[i]._datasetIndex].data[meta.data[i]._index];

                                        return {
                                            index: i,
                                            text: label + ": " + value.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }),
                                            fillStyle: custom.backgroundColor ? custom.backgroundColor : Chart.helpers.getValueAtIndexOrDefault(data.datasets[0].backgroundColor, i, chart.options.elements.arc.backgroundColor),
                                            hidden: isNaN(data.datasets[0].data[i]) || meta.data[i].hidden
                                        };
                                    });
                                } else {
                                    return [];
                                }
                            }
                        }
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
    },

    generateDataset: function (dataChart, colors) {
        var datasetsChart = [];
        if (Boolean(dataChart) && typeof dataChart[0] != "object") {
            datasetsChart.push({
                label: 'Dataset',
                data: dataChart,
                backgroundColor: colors,
                maxBarThickness: 32
            });
        }
        else {
            var labelsChart = Object.keys(dataChart[0]);
            for (var i = 0; i < labelsChart.length; i++) {
                datasetsChart.push({
                    label: labelsChart[i],
                    data: dataChart.reduce(function (result, obj) {
                        result.push(obj[labelsChart[i]]);
                        return result;
                    }, []),
                    backgroundColor: colors[i]
                })
            }
        }
        return datasetsChart;
    }
};
