import Image from 'next/image'
import { Inter } from 'next/font/google'
import Home1 from "../Components/Home"
import Contact from './Website/Contact'
import About from './Website/About'

import Team from '@/pages/Website/Team'


const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <div>
      <Home1 />
      <About />
      <Team />
      <Contact />
      

     
    </div>
  )
}
