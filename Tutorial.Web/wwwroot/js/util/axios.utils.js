axios.utils = {
    Get: function (that, url, params, sucessCallBack, failedCallBack, obj, config) {
        axios.get(url, params, config).then(response => {
            if (response == undefined || response.data == undefined) {
                that.$message({
                    type: 'error',
                    message: "服务器无响应"
                });
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that);
                }
                return;
            }
            if (response.data.StateCode == 500 || response.data.stateCode == 500) {
                console.log(response);
                that.$message({
                    type: 'error',
                    message: '服务器开小差了...'
                });
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that, response.data);
                }
                return;
            }
            if ((response.data.StateCode != 200 && response.data.StateCode != 201)
                && response.data.stateCode != 200 && response.data.stateCode != 201) {
                console.log(response);
                var msg = response.data.ResultMsg;
                msg = msg < "" ? response.data.resultMsg : msg;

                that.$message({
                    type: 'error',
                    message: msg
                });
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that, response.data);
                }
                return;
            }
            if (typeof (sucessCallBack) == "function") {
                sucessCallBack(that, response.data, obj);
            }

        }).catch(
            response => {
                that.$utils.layerErrorTip(response.message);
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that);
                }
            }
        );
    },

    Post: function (that, url, params, sucessCallBack, failedCallBack, obj, config, isShowMsg) {
        axios.post(url, params, config).then(response => {
            if (response == undefined || response.data == undefined) {
                that.$message({
                    type: 'error',
                    message: "服务器无响应"
                });
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that);
                }
                return;
            }
            if (response.data.StateCode == 500 || response.data.stateCode == 500) {
                console.log(response);
                that.$message({
                    type: 'error',
                    message: '服务器开小差了...'
                });
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that, response.data);
                }
                return;
            }
            if ((response.data.StateCode != 200 && response.data.StateCode != 201)
                && response.data.stateCode != 200 && response.data.stateCode != 201) {
                console.log(response);
                var msg = response.data.ResultMsg;
                msg = msg < "" ? response.data.resultMsg : msg;
                if (isShowMsg) {

                } else {
                    that.$message({
                        type: 'error',
                        message: msg
                    });
                }

                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that, response.data);
                }
                return;
            }
            if (typeof (sucessCallBack) == "function") {
                sucessCallBack(that, response.data, obj);
            }
        }).catch(
            response => {
                that.$utils.layerErrorTip(response.message);
                if (typeof (failedCallBack) == "function") {
                    failedCallBack(that);
                }
            }
        );
    },

    PostForListPage: function (that, url, searchModel, pageSize, pageIndex) {
        that.loading = true;
        axios.post(url,
            {
                PageSize: pageSize,
                PageIndex: pageIndex,
                searchModel: searchModel
            }).then(response => {
                that.loading = false;
                if (response == undefined || response.data == undefined) {
                    that.$message({
                        type: 'error',
                        message: "服务器无响应"
                    });
                    return;
                }
                if (response.data.StateCode == 500 || response.data.stateCode == 500) {
                    console.log(response);
                    that.$message({
                        type: 'error',
                        message: '服务器开小差了...'
                    });
                    return;
                }
                if ((response.data.StateCode != 200 && response.data.StateCode != 201)
                    && response.data.stateCode != 200 && response.data.stateCode != 201) {

                    console.log(response);
                    var msg = response.data.ResultMsg;
                    msg = msg < "" ? response.data.resultMsg : msg;
                    that.$message({
                        type: 'error',
                        message: msg
                    });
                    return;
                }
                var dataBody = response.data.Body;
                that.totalCount = dataBody.TotalCount;
                that.tableData = dataBody.List;
            }).catch(
                response => {
                    that.$utils.layerErrorTip(response.message);
                    that.loading = false;
                }
            );
    },

    PostForListPageByEntity: function (that, url, searchEntity) {
        that.loading = true;
        axios.post(url,
            searchEntity).then(response => {
                that.loading = false;
                if (response == undefined || response.data == undefined) {
                    that.$message({
                        type: 'error',
                        message: "服务器无响应"
                    });
                    return;
                }
                if (response.data.StateCode == 500 || response.data.stateCode == 500) {
                    console.log(response);
                    that.$message({
                        type: 'error',
                        message: '服务器开小差了...'
                    });
                    return;
                }
                if ((response.data.StateCode != 200 && response.data.StateCode != 201)
                    && response.data.stateCode != 200 && response.data.stateCode != 201) {

                    console.log(response);
                    var msg = response.data.ResultMsg;
                    msg = msg < "" ? response.data.resultMsg : msg;
                    that.$message({
                        type: 'error',
                        message: msg
                    });
                    return;
                }
                var dataBody = response.data.Body;
                that.totalCount = dataBody.TotalCount;
                that.tableData = dataBody.List;
            }).catch(
                response => {
                    that.$utils.layerErrorTip(response.message);
                    that.loading = false;
                }
            );
    },

    AxiosCheckResponse: function (Response, that) {
        if (!Response) {
            that.$message({
                type: 'error',
                message: '服务器返回为空'
            });
            return false;
        }
        if (!Response.data) {
            that.$message({
                type: 'error',
                message: '服务器返回实体为空'
            });
            return false;
        }
        if (Response.data.StateCode == 500 || Response.data.stateCode == 500) {
            that.$message({
                type: 'error',
                message: '服务器开小差了'
            });
            return false;
        }
        if (Response.data.StateCode && Response.data.StateCode != 200) {
            that.$message({
                type: 'error',
                message: Response.data.ResultMsg
            });
            return false;
        }
        if (Response.data.stateCode && Response.data.stateCode != 200) {
            that.$message({
                type: 'error',
                message: Response.data.ResultMsg
            });
            return false;
        }
        return true;
    }
}