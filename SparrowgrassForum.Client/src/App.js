import './styles/App.css';
import Navbar from "./components/Navbar";
import MainForm from "./components/MainForm";
import RecordList from "./components/RecordList";
import {Route, Routes} from "react-router-dom";

function App() {

    return (
        <div>
            <Navbar/>
            <Routes>
                <Route exact path='/' element={<MainForm/>}/>
                <Route path='/records' element={<RecordList/>}/>
            </Routes>
        </div>
    );
}

export default App;
