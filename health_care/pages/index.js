import Image from 'next/image'
import { Inter } from 'next/font/google'
import Home1 from "../Components/Home"
import Contact from '../Components/Contact'
import About from '../Components/About'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <div>
      <Home1 />
      <Contact />
      <About />
    </div>
  )
}
