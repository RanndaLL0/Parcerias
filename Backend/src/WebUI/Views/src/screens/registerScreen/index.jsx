import React, { useState } from "react";
import loginImage from "../../utils/images/loginImage.png";
import logo from "../../utils/images/logo.png"
import { Eye,EyeClosed } from 'lucide-react';
import { useNavigate } from "react-router-dom";

export default function RegisterScreen() {
    const [showPassword,setShowPassword] = useState(false);
    const navigation = useNavigate();

    const handleLogin = (e) => {
        e.preventDefault();
    }

    return (
        <main className="flex w-full h-screen">
            <aside className="flex justify-center items-center flex-1 h-screen">
                <form className="w-[460px]"
                    onSubmit={handleLogin}>
                    <header className="mb-8">
                        <img src={logo} alt="Logo Senac" />
                    </header>

                    <div className="flex flex-col gap-4">
                        <h1 className="text-3xl font-medium">Bem vindo de volta!</h1>
                        <h3 className="text-sm text-[#A1A1A1]">Coloque as suas credenciais para acessar a sua conta.</h3>
                    </div>

                    <div className="flex flex-col gap-2.5 w-full mt-9">
                        <h3 className="text-sm text-[#A1A1A1]">Insira o seu nome</h3>
                        <input
                            className="w-full bg-none border-1 border-[#E2E2E2]
                        bg-white py-2.5 px-3.5 rounded-sm"
                            type="text"
                            placeholder="nome" />
                    </div>

                    <div className="flex flex-col gap-2.5 w-full mt-6">
                        <h3 className="text-sm text-[#A1A1A1]">Insira o seu email</h3>
                        <input
                            className="w-full bg-none border-1 border-[#E2E2E2]
                        bg-white py-2.5 px-3.5 rounded-sm"
                            type="text"
                            placeholder="email" />
                    </div>

                    <div className="flex flex-col gap-2.5 mt-6">
                        <h3 className="text-sm text-[#A1A1A1]">Insira a sua senha</h3>
                        <div className="relative">
                            <input
                                className="w-full bg-none border-1 border-[#E2E2E2]
                                bg-white py-2.5 px-3.5 rounded-sm pr-12"
                                type={showPassword ? "text" : "password"}
                                placeholder="*****" />
                            <button 
                            type="button"
                            onClick={() => setShowPassword(!showPassword)}
                            className="absolute right-0 top-1/2 border-x-1 
                            border-[#E2E2E2] bg-white p-2 -translate-y-1/2 cursor-pointer">
                            {
                                showPassword ?
                                <Eye color="#E2E2E2" height={26} width={26} />
                                :
                                <EyeClosed color="#E2E2E2" height={26} width={26}/>
                            }
                            </button>
                        </div>
                    </div>

                    <div className="flex flex-col gap-2.5 mt-6">
                        <h3 className="text-sm text-[#A1A1A1]">Repita a sua senha</h3>
                        <div className="relative">
                            <input
                                className="w-full bg-none border-1 border-[#E2E2E2]
                                bg-white py-2.5 px-3.5 rounded-sm pr-12"
                                type={showPassword ? "text" : "password"}
                                placeholder="*****" />
                            <button 
                            type="button"
                            onClick={() => setShowPassword(!showPassword)}
                            className="absolute right-0 top-1/2 border-x-1 
                            border-[#E2E2E2] bg-white p-2 -translate-y-1/2 cursor-pointer">
                            {
                                showPassword ?
                                <Eye color="#E2E2E2" height={26} width={26} />
                                :
                                <EyeClosed color="#E2E2E2" height={26} width={26}/>
                            }
                            </button>
                        </div>
                    </div>
                    
                    <div className="flex flex-col gap-2.5 w-full mt-6">
                        <h3 className="text-sm text-[#A1A1A1]">Telefone</h3>
                        <input
                            className="w-full bg-none border-1 border-[#E2E2E2]
                        bg-white py-2.5 px-3.5 rounded-sm"
                            type="text"
                            placeholder="email" />
                    </div>

                    <button className="w-full py-2 text-white 
                    bg-[#0064FF] mt-6 cursor-pointer">Cadastrar</button>

                    <button onClick={() => navigation("/login")}
                    className="mt-6">
                        <span className=" cursor-pointer">
                            Já tem uma conta? <a className="text-[#0064FF]">Entrar</a>
                        </span>
                    </button>

                </form>
            </aside>
            <aside className="sm:hidden md:block bg-white w-1/2 p-6">
                <img
                    src={loginImage}
                    alt="Login"
                    className="w-full h-full rounded-lg object-fill"
                />
            </aside>
        </main>
    )
}