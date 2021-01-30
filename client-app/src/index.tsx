import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';

ReactDOM.render(<App />, document.getElementById('root'));

// 00:02:49.640 ~ 00:02:56.420  Dom has a single method and react on calls a render method and what this does it gets the reference
// 00:02:56.420 ~ 00:03:06.380  to the root element or I div with the idea of root and then inside this particular div it loads are
// 00:03:06.410 ~ 00:03:13.340  apt components and it's the contents of this component that we're seeing outputs into our browser page

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
