$(function () {
    Initialization();
    initialDatagrid();
    initialCombobox();
})

function initialDatagrid() {
    $.MyAJAX([], "/AccountSales/GetDataList", initDatagridSuccessful, err);
}
function initDatagridSuccessful(result) {
    if (result != "") {
        $("#dg").datagrid('loadData', result);
    }
    else {
        $.messager.alert('警告', '数据为空或加载失败！', 'warning');
    }
}

function initialCombobox() {
    $.MyAJAX([], "/ProductionCategory/GetDataList", initCmbSuccessful);
}
function initCmbSuccessful(result) {
    $("#productionName").combobox({
        data: result,
        valueField: 'Id',
        textField: 'Name',
        onSelect: function (record) {
            $('#productionUnit').textbox('setText', record.Unit);
            $('#productionCost').textbox('setText', record.Cost);
            $('#productionProfit').textbox('setText', record.Profit);
        }
    });
}

function addItem() {
    $('#editDialog').dialog('open');
}
function saveItem() {
    var dataToServer = {
        productionId: $('#productionName').combobox('getValue'),
        productionQuantity: $('#productionQuantity').numberspinner('getValue'),
        productionCost: $('#productionCost').textbox('getText'),
        productionProfit: $('#productionProfit').textbox('getText')
    }
    $.MyAJAX(dataToServer, "/AccountSales/Add", dialogSaveSuccessful, err);
}
function dialogSaveSuccessful(result) {
    if (result != "0") {
        $('#editDialog').dialog('close');
        initialDatagrid();
        $.messager.alert('提示', '保存成功', 'info');
    }
    else {
        $('#editDialog').dialog('close');
        $.messager.alert('警告', '数据添加失败！', 'warning');
    }
}

function removeItem() {
    var selectedRow = $("#dg").datagrid('getSelected');
    if (selectedRow == null) {
        $.messager.alert('警告', '未选择目标行，请选中一行数据！', 'warning');
    }
    else {
        var dataToServer = {
            id: selectedRow["Id"]
        };
        $.MyAJAX(dataToServer, "/AccountSales/Delete", dialogDeleteSuccessful, err);

        //var selectedIndex = $("#dg").datagrid('getRowIndex', selectedRow);
        //$("#dg").datagrid('deleteRow', selectedIndex);
    }
}
function dialogDeleteSuccessful(result) {
    if (result != "0") {
        $('#editDialog').dialog('close');
        initialDatagrid();
        $.messager.alert('提示', '删除成功', 'info');
    }
    else {
        $('#editDialog').dialog('close');
        $.messager.alert('警告', '数据删除失败！', 'warning');
    }
}

function statistics() {
    $("#dd").dialog('open');
}

function Initialization() {

    $('#dg').datagrid({
        data: [],
        title: '销售信息',
        toolbar: '#tb',
        singleSelect: true, rownumbers: true, striped: true,
        columns: [[
            {
                field: 'ProductionCategoryCode', title: '产品编号', width: '20%', align: 'center'
            },
            {
                field: 'ProductionCategoryName', title: '产品名称', width: '20%', align: 'center'
            },
            {
                field: 'ProductionCategoryUnit', title: '单位', width: '10%', align: 'center'
            },
            {
                field: 'Quantity', title: '销售量', width: '15%', align: 'center'
            },
            {
                field: 'TotalCost', title: '总成本', width: '15%', align: 'center'
            },
            {
                field: 'TotalProfit', title: '总利润', width: '18%', align: 'center'
            }
        ]]
    });

    $('#editDialog').dialog({
        title: '编辑销售信息', width: 600, height: 400, closed: true,
        toolbar: [{
            text: '保存',
            iconCls: 'icon-save',
            handler: function () { saveItem() }
        }, {
            text: '帮助',
            iconCls: 'icon-help',
            handler: function () { alert('help') }
        }]
    });

    $('#dd').dialog({
        title: '利润统计分析', width: 600, height: 400, closed: true,
        toolbar: [{
            text: '保存',
            iconCls: 'icon-save',
            handler: function () { dialogSave() }
        }, {
            text: '帮助',
            iconCls: 'icon-help',
            handler: function () { alert('help') }
        }]
    });
}

function err() {
    $.messager.alert('警告', '程序执行错误！', 'warning');
}