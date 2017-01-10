//获取URL参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


//为避免冲突，将我们的方法用一个匿名方法包裹起来
(function ($) {
    //扩展这个方法到jquery
    $.fn.extend({
        //加载datagrid方法
        initGrid: function (options) {
            var defaults = {
                columns: [[]],//列名
                frozenColumns: [[]],//固定列
                fitColumns: true,//是否撑满列
                resizeHandle: "right",//用户可以通过拖拽调整列宽,'left','right','both'.
                autoRowHeight: true,//定义是否设置行高基于这一行的内容。设置为false可以提高加载性能。
                striped: true, //即奇偶行使用不同背景色
                method: 'post',
                nowrap: true,//不换行
                idField: null,
                url: '',//数据来源
                data: null,//表格数据
                loadMsg: '正在拼命加载。。。',
                emptyMsg: '没有更多数据',
                pagination: true,//显示分页栏
                rownumbers: true,//显示行号
                singleSelect: false,//是否单选
                ctrlSelect: true,//允许按住ctrl选择数据行
                checkOnSelect: true,//点击数据行选中数据
                selectOnCheck: true,//
                pagePosition: 'bottom',//'top','bottom','both'工具栏位置
                pageNumber: 1,//页码
                pageSize: 20,//一页显示多少数据
                pageList: [10, 20, 30, 40, 50],
                queryParams: {},//自定义查询参数
                sortName: null,//排序字段
                sortOrder: 'asc',//排序方式
                multiSort: false,//允许多个字段排序
                remoteSort: true,//定义是否来自服务器的数据进行排序
                showHeader: true,//是否显示头部
                showFooter: false,//是否显示合计行
                scrollbarSize: 18,//滚动条的宽度(垂直滚动条时)或高度(水平滚动条时)
                rownumberWidth: 30,//行号列的宽度
                editorHeight: 24,//默认编辑器高度
                rowStyler: function (index, row) { },//修改行颜色
                loadFilter: function (data) {
                    if (data.rows) {
                        return data.rows;
                    }
                    else {
                        return data;
                    }
                },//过滤数据
                onSortColumn: function (sort, order) {
                    var params = $(this).datagrid('options').queryParams;
                    params.sortName = sort;
                    params.sortOrder = order;
                    $(this).datagrid('reload');
                },//排序
                onLoadSuccess: function (data) {
                },
                onLoadError: function () {
                }
            };

            var options = $.extend(defaults, options);

            //遍历匹配元素的集合
            return this.each(function () {
                //在这里编写相应代码进行处理 
                $(this).datagrid(options);
                $(this).datagrid('resize', { height: $(window).height() - 30, width: $(window).width() });
            });


        }
    });
    //传递jQuery到方法中，这样我们可以使用任何javascript中的变量来代替"$"      
})(jQuery);

