//import logo from './logo.svg';
import './App.css';
import { Greet } from './components/Greet'
import { Clock } from './components/Clock'
import { LoginControl } from './components/LoginControl';

function App() {
  return (
    <div className="App">
      <LoginControl />
      <Greet />
      <Clock timezone={1} />
      <Clock timezone={2} />
      <Clock timezone={3} />
    </div>
  );
}

export default App;