import Link from "next/link";
import { BackgroundLines } from "../components/ui/background-lines";

export default function Home() {
    return (
        <BackgroundLines className="flex min-h-screen flex-col justify-center bg-[#16213E] py-12 sm:px-6 lg:px-8">
            <div className="sm:mx-auto sm:w-full sm:max-w-md z-10">
                <h2 className="mt-6 text-center text-4xl font-extrabold text-[#F9F9F9]">
                    Welcome to MyChatRoom
                </h2>
                <p className="mt-2 text-center text-xl text-[#F9F9F9]">
                    <Link href="/login" className="font-bold text-blue-600 hover:text-[#F9F9F9]">
                        sign in
                    </Link>

                    {' '}Or{' '}

                    <Link href='/signup' className="font-bold text-blue-600 hover:text-[#F9F9F9]">
                        create a new account
                    </Link>
                </p>
            </div>
        </BackgroundLines>
    );
}
