import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Persons from './components/Persons';
import Person from './components/Person';
import Lifeevents from './components/Lifeevents';
import Lifeevent from './components/Lifeevent';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/persons/:startDateIndex?' component={Persons} />
    <Route path='/person/:id' component={Person} />
    <Route path='/person-create/:id' component={Person} />
    <Route path='/lifeevents/:startDateIndex?' component={Lifeevents} />
    <Route path='/lifeevent/:id' component={Lifeevent} />
  </Layout>
);
