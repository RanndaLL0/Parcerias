import React, { useState } from "react";
import { Eye, EyeClosed } from "lucide-react";

export default function CustomInput({...props}) {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <div className="flex flex-col gap-2.5 mt-6">
            {
                props.type === "password" ?
                    <>
                        <h3 className="text-sm text-[#A1A1A1]">{props.text}</h3>
                        <div className="relative">
                            <input
                                onChange={props.action}
                                className="w-full bg-none border-1 border-[#E2E2E2]
                                bg-white py-2.5 px-3.5 rounded-sm pr-12"
                                value={props.value}
                                type={props.showPassword ? "text" : "password"}
                                placeholder={props.placeholder} />
                            <button
                                type="button"
                                onClick={() => setShowPassword(!props.showPassword)}
                                className="absolute right-0 top-1/2 border-x-1 
                            border-[#E2E2E2] bg-white p-2 -translate-y-1/2 cursor-pointer">
                                {
                                    showPassword ?
                                        <Eye color="#E2E2E2" height={26} width={26} />
                                        :
                                        <EyeClosed color="#E2E2E2" height={26} width={26} />
                                }
                            </button>
                        </div>
                    </>
                    :
                    <>
                        <div className="flex flex-col gap-2.5 w-full mt-9">
                            <h3 className="text-sm text-[#A1A1A1]">{props.text}</h3>
                            <input
                                onChange={props.action}
                                className="w-full bg-none border-1 border-[#E2E2E2]
                                bg-white py-2.5 px-3.5 rounded-sm"
                                type="text"
                                value={props.value}
                                placeholder={props.placeholder} />
                        </div>
                    </>
            }
        </div>
    )
}