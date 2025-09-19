import React from "react";
import loginImage from "../../utils/images/loginImage.png";
import logo from "../../utils/images/logo.png";
import { useNavigate } from "react-router-dom";
import CustomInput from "../../components/loginInputs";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

const schema = yup.object({
  Email: yup.string().email("Formato inválido").required("Informe seu email"),
  Password: yup.string().required("É preciso que você informe a senha"),
}).required();

export default function LoginPage() {
  const navigation = useNavigate();

  const { handleSubmit, control } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      Email: "",
      Password: "",
    },
  });

  const onSubmit = (data) => {
    console.log("Login data:", data);
  };

  return (
    <main className="flex w-full h-screen">
      <aside className="flex justify-center items-center flex-1 h-screen">
        <form className="w-[460px]" onSubmit={handleSubmit(onSubmit)}>
          <header className="mb-8">
            <img src={logo} alt="Logo Senac" />
          </header>

          <div className="flex flex-col gap-4">
            <h1 className="text-3xl font-medium">Bem vindo de volta!</h1>
            <h3 className="text-sm text-[#A1A1A1]">
              Coloque as suas credenciais para acessar a sua conta.
            </h3>
          </div>

          <Controller
            name="Email"
            control={control}
            render={({ field, fieldState }) => (
              <CustomInput
                text="Entre com o seu email"
                placeholder="E-mail"
                value={field.value}            
                action={field.onChange}        
                error={fieldState.error?.message}
              />
            )}
          />

          <Controller
            name="Password"
            control={control}
            render={({ field, fieldState }) => (
              <CustomInput
                text="Entre com a sua senha"
                placeholder="******"
                type="password"
                value={field.value}            
                action={field.onChange}        
                error={fieldState.error?.message}
              />
            )}
          />

          <input
            type="submit"
            value="Login"
            className="w-full py-2 text-white bg-[#0064FF] mt-6 cursor-pointer"
          />

          <button
            type="button"
            onClick={() => navigation("/register")}
            className="mt-9"
          >
            <span className="mt-9 cursor-pointer">
              Não tem uma conta?{" "}
              <a className="text-[#0064FF]">Registrar</a>
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
  );
}
