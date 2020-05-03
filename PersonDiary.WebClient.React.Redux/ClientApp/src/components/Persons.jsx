import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { actionCreators } from '../store/Person.store';
import { Pagination } from 'antd'

class Persons extends Component {

    constructor(props) {
        super(props);
        this.state = { PageNo: 0 };
        this.props.requestPersons(this.state.PageNo);
    }
   
    onPageChange = page => {
        this.setState({
            PageNo: page,
        });
        this.props.requestPersons(page-1);
    };
    render() {
        return (
            <div>
                
                <h1>Person list</h1>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Surname</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.persons.map(person =>
                            <tr key={person.id}>
                                <td><Link to={"/person/" + person.id}>{person.id}</Link></td>
                                <td><NavLink to={"/person/" + person.id}>{person.name}</NavLink></td>
                                <td><NavLink to={"/person/" + person.id}>{person.surname}</NavLink></td>
                            </tr>
                        )}
                    </tbody>
                </table>
                {this.props.persons.length > 0 && <Pagination current={this.state.PageNo} onChange={this.onPageChange} total={this.props.count} />}
                {this.props.persons.length == 0 && "Loading..."}
            </div>
        );
    }
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Persons);