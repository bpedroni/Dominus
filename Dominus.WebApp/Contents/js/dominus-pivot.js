window.$dominusPivot = {

    sorters: {
        "Mês": $.pivotUtilities.sortAs(["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"]),
        "Tipo": $.pivotUtilities.sortAs(["Receita", "Despesa"]),
        "Modo": $.pivotUtilities.sortAs(["Transação", "Provisão"])
    },

    renderers: {},

    loadRenderers: function (array, propName, propFunction) {
        try {
            for (var i = 0; i < array.length; i++) {
                this.renderers[array[i][propName]] = eval(array[i][propFunction]);
            }
        } catch (e) {
            console.log(e);
        }
    },

    createPivotUI: function (div, data, rowsArray, colsArray, renderer) {
        try {
            div.pivotUI(data, {
                rows: rowsArray || [],
                cols: colsArray || [],
                aggregators: {
                    "Total em reais": function () {
                        return $.pivotUtilities.aggregatorTemplates.sum($.pivotUtilities.numberFormat({
                            thousandsSep: ".",
                            decimalSep: ",",
                            prefix: "R$ "
                        }))(["Valor"]);
                    }
                },
                renderers: $dominusPivot.renderers,
                rendererName: renderer || null,
                sorters: $dominusPivot.sorters
            }, true);
        } catch (e) {
            console.log(e);
        }
    },

    pivotOptions: function (div) {
        try {
            return div.data("pivotUIOptions") || {};
        } catch (e) {
            console.log(e);
        }
    }
};
