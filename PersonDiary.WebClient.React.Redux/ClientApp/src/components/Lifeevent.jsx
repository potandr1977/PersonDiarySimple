import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Lifeevent.store';
import { DatePicker, Button, Alert  } from 'antd';
import moment from 'moment';
import { CommonUtils } from '../components/common/common.utils';

const { MonthPicker, RangePicker } = DatePicker;
const dateFormat = 'YYYY/MM/DD';
const monthFormat = 'YYYY/MM';
const dateFormatList = ['DD/MM/YYYY', 'DD/MM/YY'];

class Lifeevent extends Component {
    displayName = Lifeevent.name;   

    constructor(props) {
        super(props);
        this.state = { name: undefined, eventdate: undefined};
        this.onChange = this.onChange.bind(this);
        this.onChangeDate = this.onChangeDate.bind(this);
        this.save = this.save.bind(this);

        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestLifeEvent(id);
        this.id = id;
        this.PersonId = undefined;
    }
    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        if (nextProps.lifeevent && nextProps.lifeevent.id == this.id) {
            this.setState({
                name: nextProps.lifeevent.name,
                eventdate: nextProps.lifeevent.eventdate,
                hasDeleteError: nextProps.hasDeleteError,
                hasSaveError: nextProps.hasSaveError,
                lifeevent: nextProps.lifeevent
            });
            this.personId = nextProps.lifeevent.personId;
        }
    }
    onChange(e) {
        var fieldname = e.target.name;
        var newstate = {};
        newstate[fieldname] = e.target.value;
        this.setState(newstate);
    }
    onChangeDate(date, dateString) {
        this.setState({ eventdate: dateString });
    }
    save(e) {
        this.state.lifeevent.name = this.state.name;
        this.state.lifeevent.eventdate = CommonUtils.correctDate2UTC(this.state.eventdate);
        this.props.saveLifeEvent(this.state.lifeevent);
    }
    delete = () => {
        this.props.deleteLifeEvent(this.state.lifeevent);
    };

    render() {

        if (this.state.name) {
            return (
                <div>
                    <h1>LifeEvent</h1>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text" name="name" value={this.state.name} onChange={this.onChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label>Date</label><br/>
                        <DatePicker defaultValue={moment(this.state.eventdate, dateFormat)} format={dateFormat} onChange={this.onChangeDate} />
                    </div>
                    <div className="form-group">
                        <Button type="primary" onClick={this.save} style={{ marginRight: "5px" }}>Save</Button>
                        <Button type="danger" onClick={this.delete}>Delete</Button>
                    </div>
                    {this.state.hasDeleteError === true &&
                        <Alert message="Error! Event has not been deleted" type="error" />
                    }
                    {this.state.hasSaveError === true &&
                        <Alert message="Error! Event has not been saved" type="error" />
                    }
                    {this.state.hasSaveError === false &&
                        <Alert message="Success! Person has been succcessfully saved" type="success" />
                    }
                </div>
            )
        }
        else return "loading...";
    }
}

export default connect(
    state => state.reducerLifeEvent,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Lifeevent);