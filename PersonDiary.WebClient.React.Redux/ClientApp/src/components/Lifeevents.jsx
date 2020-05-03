import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { actionCreators } from '../store/Lifeevent.store';
import { CommonUtils } from '../components/common/common.utils';


class LifeEvents extends Component {
    constructor(props) {
        super(props);
    }
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestLifeEvents(startDateIndex);
    }
    
   

    render() {
        return (

            <div>
                <h1>Event list</h1>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Person</th>
                            <th>Event</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.lifeevents.map(lifeevent =>
                            <tr key={lifeevent.id}>
                                <td><NavLink to={"/lifeevent/" + lifeevent.id}>{lifeevent.personfullname}</NavLink></td>
                                <td><NavLink to={"/lifeevent/" + lifeevent.id}>{lifeevent.name}</NavLink></td>
                                <td><NavLink to={"/lifeevent/" + lifeevent.id}>{CommonUtils.formatDate(lifeevent.eventdate)}</NavLink></td>
                            </tr>
                        )}
                    </tbody>
                </table>
                {this.props.lifeevents.length == 0 && "Loading..."}
            </div >

        );
    }
}





export default connect(
    state => state.reducerLifeEvent,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(LifeEvents);