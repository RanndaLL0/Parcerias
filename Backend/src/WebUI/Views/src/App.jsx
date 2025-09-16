import { useState } from 'react'
import RegisterScreen from './screens/registerScreen'
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import LoginPage from './screens/loginPage';


function App() {
  const [count, setCount] = useState(0)

  return (
    <BrowserRouter>
      <Routes>
          <Route path='/' element={<Navigate to="/login" replace/>}/>
          <Route  path="/login" element={<LoginPage/>}/>
          <Route path="/register" element={<RegisterScreen/>}/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
