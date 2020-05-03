import React, { Component } from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { actionCreators } from "../store/Person.store";
import { Link } from "react-router-dom";
import { Upload, message, Button, Icon, Alert, Modal } from "antd";
import { CommonUtils } from "../components/common/common.utils";

const { confirm } = Modal;

class Person extends Component {
    displayName = Person.name;

    constructor(props) {
        super(props);

        this.onChange = this.onChange.bind(this);
        this.downldoadfile = this.downldoadfile.bind(this);
        this.deletefile = this.deletefile.bind(this);
        this.confirmDelete = this.confirmDelete.bind(this);

        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestPerson(id);
        this.id = id;

        this.state = {
            id: this.id,
            name: undefined,
            surname: undefined,
            lifeevents: undefined,
            file_list: [],
            uploading: false,
            has_file: false,
            is_name_valid: true,
            is_surname_valid: true,
            person: undefined
        };
    }

    validateTextField(value) {
        return (value) ? true : false;
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.person && nextProps.person.id == this.id) {
            this.setState({
                name: nextProps.person.name,
                surname: nextProps.person.surname,
                lifeevents: nextProps.person.lifeEvents,
                has_file: nextProps.person.hasFile,
                hasDeleteError: nextProps.hasDeleteError,
                hasSaveError: nextProps.hasSaveError,
                person: nextProps.person
            });
            if (nextProps.hasDeleteError === false)
                this.props.history.push("/persons");
        }

    }

    onChange = e => {
        const newstate = {};
        newstate[e.target.name] = e.target.value;
        newstate[`is_${e.target.name}_valid`] = this.validateTextField(e.target.value);
        this.setState(newstate);
    };

    save = () => {
        this.state.person.name = this.state.name;
        this.state.person.surname = this.state.surname;
        this.props.savePerson(this.state.person);
    };

    delete = () => {
        this.props.deletePerson(this.state.person);
    };

    //загрузка файла биографии на сервер
    handleUpload = () => {
        const { file_list } = this.state;

        const formData = new FormData();
        file_list.forEach(file => {
            formData.append("files[]", file);
        });

        var _this = this;
        var oReq = new XMLHttpRequest();
        oReq.open("POST", `/api/personfile/?json=${JSON.stringify({ PersonId: _this.id })}`, true);
        oReq.onload = function(oEvent) {
            if (oReq.status === 200) {
                console.log("upload succes", oReq.responseText);
                const resp = JSON.parse(oReq.response);
                if (resp.messages.filter(x => x.type == 1).length > 0) {
                    var messageTextSummary = "";
                    resp.messages.forEach(function(message, idx) {
                        messageTextSummary += ` ${message.text}`;
                    });
                    message.error(`Error ${messageTextSummary}`);
                } else {
                    _this.setState({ has_file: true });
                    message.success("Success!, File uploaded");
                }
                _this.setState({
                    uploading: false,
                });

            } else {
                console.log(`Error ${oReq.status} occurred when trying to upload your file.<br \/>`);
            }
        };
        oReq.send(formData);
        this.setState({
            file_list: [],
            uploading: false,
        });
    };

    //Удаление файла биографии
    deletefile = () => {

        fetch(`api/PersonfILE/${this.id}`,
            {
                method: "DELETE",
                headers: {
                    'Accept': "application/json",
                    'Content-Type': "application/json"
                }
            }).then(response => {
            if (response.status === 200) {
                this.setState({ has_file: false });
                message.success("Success!, File has been deleted");
            }
        }).catch(() => {
            message.error("Error!, File has not been deleted");
        });

    };

    downldoadfile = () => {
        return <Link to={`/api/personfile/${this.id}`}/>;
    };

    confirmDelete() {
        var _this = this;
        confirm({
            title: "Do you want to delete these items?",
            content: "Are you sure you want delete this item?",
            onOk() {
                _this.delete();
            },
            onCancel() {
            },
        });
    }

    static renderLifeEvents(lifeevents) {
        if (lifeevents)
            return (
                <table className="table">
                    <thead>
                    <tr>
                        <th>Name</th>
                        <th>Date</th>
                    </tr>
                    </thead>
                    <tbody>
                    {lifeevents.map(lifeevent => <tr key={lifeevent.id}>
                                                     <td>
                                                         <Link to={`/lifeevent/${lifeevent.id}`}>{lifeevent.name
                                                         }</Link>
                                                     </td>
                                                     <td>
                                                         <Link to={`/lifeevent/${lifeevent.id}`}>{CommonUtils
                                                             .formatDate(
                                                                 lifeevent.eventdate)}</Link>
                                                     </td>

                                                 </tr>)}
                    </tbody>
                </table>
            );
        else return "";
    }

    render() {
        const { uploading, file_list } = this.state;
        const props = {
            accept: ".docx,.doc",
            onRemove: file => {
                this.setState(state => {
                    const index = state.file_list.indexOf(file);
                    const newfile_list = state.file_list.slice();
                    newfile_list.splice(index, 1);
                    return {
                        file_list: newfile_list,
                    };
                });
            },
            beforeUpload: file => {
                this.setState(state => ({
                    file_list: [file],
                }));
                return false;
            },
            file_list,
        };

        if (this.state.lifeevents) {
            const contents = Person.renderLifeEvents(this.state.lifeevents);

            return (
                <form>
                    <h1>Person</h1>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text" name="name" value={this.state.name} onChange={this.onChange
} className="form-control"/>
                        {!this.state.is_name_valid === true &&
                            <Alert message="Name must be filled" type="error"/> }
                    </div>
                    <div className="form-group">
                        <label>Surname</label>
                        <input type="text" name="surname" value={this.state.surname} onChange={this.onChange
} className="form-control"/>
                        {!this.state.is_surname_valid === true &&
                            <Alert message="Surname must be filled" type="error"/> }
                    </div>
                    {!this.state.has_file &&
                        <div className="form-group">
                            <div className="col">
                                <Upload {...props}>
                                    <Button>
                                        <Icon type="upload"/> Select File
                                    </Button>
                                </Upload>
                            </div>
                            <div className="col">
                                <Button
                                    type="primary"
                                    onClick={this.handleUpload}
                                    disabled={file_list.length === 0}
                                    loading={uploading}
                                    style={{ marginTop: 16 }}>
                                    {uploading ? "Uploading" : "Start Upload"}
                                </Button>
                            </div>
                        </div> }
                    {this.state.has_file &&
                        <div className="form-group">
                            <Button type="primary" onClick={this.downldoadfile} style={{ marginRight: "5px" }}>
                                <Link target="_blank" to={`/api/personfile/${this.id}`}>Download biography</Link>
                            </Button>
                            <Button type="danger" onClick={this.deletefile}>Delete biography</Button>
                        </div> }
                    <div className="form-group">
                        <Button type="primary" disabled={!this.state.is_name_valid || !this.state.is_surname_valid
} onClick={this.save} style={{ marginRight: "5px" }}>Save</Button>
                        <Button type="danger" onClick={this.confirmDelete}>Delete</Button>
                    </div>
                    {this.state.hasDeleteError === true &&
                        <Alert message="Error! Person has not been deleted" type="error"/> }
                    {this.state.hasSaveError === true &&
                        <Alert message="Error! Person has not been saved" type="error"/> }
                    {this.state.hasSaveError === false &&
                        <Alert message="Success! Person has been succcessfully saved" type="success"/> }
                    {contents}
                </form>
            );
        } else return "loading...";
    }
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Person);