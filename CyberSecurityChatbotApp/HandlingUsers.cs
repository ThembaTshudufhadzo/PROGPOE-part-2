using System;
using System.Collections.Generic;
using System.Threading;

namespace CyberSecurityChatbotApp
{
    internal class HandlingUsers
    {
        // Dictionary to store the chatbot's responses
        public static Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // --- General Questions ---
            {"what can i ask you?", "You can ask me specific questions about password safety, phishing, safe browsing, malware, social engineering, data privacy, and network security."},
            {"what is your purpose?", "My purpose is to provide you with information and raise awareness about cybersecurity best practices."},
            {"how are you?", "I'm functioning well, ready to assist you with your cybersecurity questions."},

            // --- Password Safety ---
            {"what makes a strong password?", "A strong password uses a mix of uppercase and lowercase letters, numbers, and symbols and is at least 12 characters long."},
            {"how can i create a strong password?", "Combine uppercase and lowercase letters, numbers, and special symbols. Aim for a length of 12 or more characters."},
            {"what is password strength?", "Password strength refers to how resistant a password is to guessing or cracking attempts."},
            {"is it safe to reuse passwords?", "No, it's not safe. Reusing passwords means if one account is compromised, others are also vulnerable."},
            {"should i use a password manager?", "Yes, a password manager can generate and securely store complex, unique passwords for all your accounts."},
            {"what is two factor authentication?", "Two-factor authentication (2FA) adds an extra security layer requiring a second verification method besides your password."},
            {"how does 2fa work?", "2FA typically involves something you know (password) and something you have (like a code from an app or a physical key)."},
            {"what is multi factor authentication?", "Multi-factor authentication (MFA) is similar to 2FA but uses more than two verification factors."},
            {"how does biometric authentication work?", "Biometric authentication uses unique biological traits like fingerprints or facial scans to verify your identity."},
            {"what is a passpharse?", "A passphrase is a sequence of words used like a password, often longer and easier to remember but still strong."},
            {"how long should my password be?", "Aim for a password that is at least 12 characters long; longer is generally better."},

            // --- Phishing ---
            {"what is phishing?", "Phishing is a type of online fraud where attackers try to trick you into revealing personal information via deceptive emails, websites, or messages."},
            {"what is a suspicious email?", "A suspicious email often asks for personal information, contains unexpected attachments, creates a sense of urgency, or has poor grammar."},
            {"what are the signs of a phishing email?", "Look for suspicious sender addresses, generic greetings, urgent requests, typos, grammatical errors, and mismatched links."},
            {"how can i avoid phishing attacks?", "Be cautious of unsolicited emails, don't click suspicious links directly, verify sender legitimacy through official channels, and be wary of urgent requests."},
            {"what should i do if i clicked a phishing link?", "Immediately change your passwords for any potentially compromised accounts and notify the affected service provider or your IT department."},
            {"what is spear phishing?", "Spear phishing is a targeted phishing attack aimed at a specific individual or organization, often using personalized information."},
            {"what is whaling in cybersecurity?", "Whaling is a type of spear phishing that targets high-profile individuals such as CEOs or senior executives."},
            {"what is smishing?", "Smishing is phishing conducted through SMS (text messages)."},
            {"what is vishing?", "Vishing is phishing conducted through phone calls or voice messages."},

            // --- Safe Browsing ---
            {"what is safe browsing?", "Safe browsing involves practices that minimize security risks while using the internet, such as checking for HTTPS, avoiding suspicious sites, and using reputable search engines."},
            {"how can i ensure website security?", "Look for 'HTTPS' in the URL and the padlock icon in the browser. Be cautious on unfamiliar sites and avoid downloading from untrusted sources."},
            {"is http secure to use?", "No, HTTP is not secure. Data transmitted over HTTP is not encrypted and can be intercepted. Always use websites with 'HTTPS'."},
            {"what does https mean?", "HTTPS (Hypertext Transfer Protocol Secure) indicates a secure connection where communication between your browser and the website is encrypted, protecting your data."},
            {"is it safe to download from unknown sites?", "No, downloading files from unknown or untrusted websites can expose your system to malware and other security threats."},
            {"what about browser extension security?", "Only install browser extensions from trusted sources and review their permissions carefully before installing. Malicious extensions can compromise your browser security and privacy."},
            {"what is a secure search engine?", "A secure search engine prioritizes user privacy and often doesn't track your searches or personalize results based on your history."},
            {"should i use a vpn for browsing?", "A VPN (Virtual Private Network) can enhance your browsing privacy and security by encrypting your internet traffic and masking your IP address, especially on public Wi-Fi."},

            // --- Malware ---
            {"what is malware?", "Malware (malicious software) is any software designed to harm your computer systems, networks, or data. This includes viruses, worms, ransomware, and spyware."},
            {"what is a computer virus?", "A computer virus is a type of malware that attaches itself to other programs or files and spreads when those programs are executed or files are opened."},
            {"what is a computer worm?", "A computer worm is a type of malware that can replicate itself and spread to other computers on a network without needing to attach to a host program."},
            {"what is ransomware?", "Ransomware is a type of malware that encrypts your files and demands a ransom payment, usually in cryptocurrency, to restore access. Paying is generally not recommended as it doesn't guarantee file recovery."},
            {"what is spyware?", "Spyware is a type of malware that secretly monitors your computer activity, collects personal data (like keystrokes, browsing history, and passwords), and transmits it to attackers without your knowledge."},
            {"how can i protect against malware?", "Keep your operating system and software updated, use reputable antivirus software and keep it updated, be cautious about opening suspicious attachments or clicking unknown links, and avoid downloading from untrusted sources."},
            {"what is antivirus software?", "Antivirus software is designed to detect, prevent, and remove malware from your computer system. Regular updates are crucial for it to recognize new threats."},
            {"what is a firewall?", "A firewall is a network security system that monitors and controls incoming and outgoing network traffic based on predetermined security rules. It helps prevent unauthorized access to your system."},
            {"what is a trojan horse?", "A Trojan horse is a type of malware that disguises itself as a legitimate program to trick users into running it, often leading to system compromise or data theft."},
            {"what is adware?", "Adware is software that displays unwanted advertisements on your computer, often bundled with free software."},
            {"what is a rootkit?", "A rootkit is a type of malware designed to gain administrator-level access to a computer system while actively concealing its presence."},
            {"what is a keylogger?", "A keylogger is a type of spyware that records the keys pressed on your keyboard, allowing attackers to steal passwords and other sensitive information."},

            // --- Social Engineering ---
            {"what is social engineering?", "Social engineering is the manipulation of people into revealing confidential information or performing actions that compromise security. It exploits human psychology rather than technical vulnerabilities."},
            {"what is pretexting?", "Pretexting involves creating a false scenario or identity to trick someone into divulging information they otherwise wouldn't share."},
            {"what is baiting in social engineering?", "Baiting uses enticing offers, such as infected physical media (like USB drives) or promises of valuable rewards, to lure victims into malicious traps."},
            {"what is quid pro quo in social engineering?", "Quid pro quo (something for something) offers a benefit or service in exchange for sensitive information or the performance of a security-compromising action."},
            {"what is tailgating in physical security?", "Tailgating (or piggybacking) is a physical social engineering tactic where an unauthorized person follows an authorized individual into a restricted area."},
            {"what is dumpster diving in security?", "Dumpster diving involves looking through trash to find discarded documents or media that may contain sensitive information."},
            {"what is shoulder surfing?", "Shoulder surfing is the act of looking over someone's shoulder to steal their passwords or other sensitive information as they type it or view it."},

            // --- Data Privacy ---
            {"what is data privacy?", "Data privacy is the right of individuals to control how their personal information is collected, used, and shared."},
            {"what is a privacy policy?", "A privacy policy is a statement by a website or service that explains how it collects, uses, stores, and shares your personal data."},
            {"what is gdpr?", "GDPR (General Data Protection Regulation) is a European Union law that sets guidelines for the collection and processing of personal information of individuals within the EU."},
            {"what is ccpa?", "CCPA (California Consumer Privacy Act) is a California state law that gives consumers more control over their personal information that businesses collect."},
            {"what are cookies in web browsing?", "Cookies are small text files that websites store on your browser or device to remember information about you and your browsing activity."},
            {"what are third party cookies?", "Third-party cookies are set by a domain other than the website you are currently visiting, often used for tracking and advertising purposes."},
            {"how can i protect my online privacy?", "Review privacy policies, adjust cookie settings, use privacy-focused browsers and search engines, be cautious about sharing personal information online, and consider using a VPN."},

            // --- Network Security ---
            {"what is network security?", "Network security encompasses the measures taken to protect a computer network and its data from unauthorized access, use, disclosure, disruption, modification, or destruction."},
            {"what is a vpn?", "A VPN (Virtual Private Network) creates a secure, encrypted connection over a less secure network, such as the internet. It helps protect your online privacy and security by masking your IP address and encrypting your data traffic."},
            {"how can i secure my wi-fi?", "Use a strong and unique password (WPA3 is recommended), enable network encryption, consider hiding your network name (SSID), and keep your router firmware updated."},
            {"what is a firewall in network security?", "A firewall acts as a barrier between your network and the outside world, controlling network traffic based on security rules to block unauthorized access and malicious activity."},
            {"what is network segmentation?", "Network segmentation divides a network into smaller, isolated segments. This limits the damage if one segment is compromised and improves overall security."},
            {"what is intrusion detection system?", "An Intrusion Detection System (IDS) monitors network traffic for suspicious activity and alerts administrators when threats are detected."},
            {"what is intrusion prevention system?", "An Intrusion Prevention System (IPS) goes beyond detection by actively blocking or preventing malicious network traffic."},
            {"what is mac address filtering?", "MAC address filtering allows only devices with specific MAC addresses to connect to a network."},
            {"what is a demilitarized zone (DMZ)?", "A DMZ is a network segment that sits between an organization's internal network and an untrusted external network (like the internet), often hosting publicly accessible servers while protecting the internal network."},

            // --- Incident Response ---
            {"what is incident response?", "Incident response is the organized approach to addressing and managing the aftermath of a security breach or cyberattack. Its goal is to limit damage and reduce recovery time and costs."},
            {"how do i report a security incident?", "Report it immediately to your IT department, security team, or the relevant authorities according to your organization's policies."},
            {"what are the steps in incident response?", "Common steps include preparation, identification, containment, eradication, recovery, and lessons learned."},
            {"what is digital forensics?", "Digital forensics is the process of identifying, preserving, analyzing, and presenting digital evidence for legal or investigative purposes, often used in incident response."},
            {"what is business continuity?", "Business continuity refers to the plans and processes an organization puts in place to ensure that essential functions can continue during and after a disruption."},
            {"what is disaster recovery?", "Disaster recovery focuses on the technical aspects of restoring IT infrastructure and operations after a disruptive event."},

            // --- Definitions of Headings ---
            {"define password safety", "Password safety refers to the practices and measures taken to create, use, and protect passwords to prevent unauthorized access to accounts and information."},
            {"define phishing", "Phishing is a type of cybercrime where attackers attempt to deceive individuals into revealing sensitive information (like usernames, passwords, credit card details) by disguising themselves as trustworthy entities in electronic communications."},
            {"define safe browsing", "Safe browsing encompasses the practices and tools used to minimize security risks and protect privacy while navigating the internet."},
            {"define malware", "Malware is an umbrella term for software designed to intentionally cause harm or damage to a computer, network, server, client, or computer user."},
            {"define social engineering in cybersecurity", "In cybersecurity, social engineering refers to psychological manipulation techniques used to trick people into making security mistakes or giving away sensitive information."},
            {"define data privacy", "Data privacy (or information privacy) is the aspect of information technology that deals with the ability an organization or individual has to determine what data in a computer system can be shared with third parties."},
            {"define network security", "Network security consists of the policies and practices adopted to prevent and monitor unauthorized access, misuse, modification, or denial of a computer network and network-accessible resources."},
            {"define incident response", "Incident response is a structured approach to managing the consequences of a security incident or data breach. It involves identifying, containing, eradicating, recovering from, and learning from security incidents."}
        };

        // Method to simulate a typing effect
        public static void TypeWriteLine(string message, int delay = 30)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Class for handling user input and providing responses
        public static void HandleUserInput(string userName) // Made static
        {
            Console.WriteLine($"Hello, {userName}! Ask me anything about cybersecurity (or type 'exit' to quit).");
            Console.WriteLine($"You can ask me about topics like 'passwords', 'phishing', 'browsing', 'malware', 'social engineering', 'data privacy', 'network security', 'incident response', and definitions of these terms.");

            while (true)
            {
                Console.Write($"{userName}: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine()?.ToLower().Trim();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a question or command.");
                    continue;
                }

                if (input == "exit" || input == "quit")
                {
                    Console.WriteLine("Goodbye! Stay safe online!");
                    break;
                }
                else
                {
                    bool foundResponse = false;
                    foreach (var entry in responses)
                    {
                        if (input.Contains(entry.Key))
                        {
                            Console.Write("Bot: ");
                            TypeWriteLine(entry.Value);
                            foundResponse = true;
                            break;
                        }
                    }

                    if (!foundResponse)
                    {
                        Console.Write("Bot: ");
                        Console.WriteLine("I didn't quite understand that. Could you please rephrase your question or ask about a different cybersecurity topic? You can ask about:");
                        Console.WriteLine("- Password Safety");
                        Console.WriteLine("- Phishing");
                        Console.WriteLine("- Safe Browsing");
                        Console.WriteLine("- Malware");
                        Console.WriteLine("- Social Engineering");
                        Console.WriteLine("- Data Privacy");
                        Console.WriteLine("- Network Security");
                        Console.WriteLine("- Incident Response");
                        Console.WriteLine("- Definitions of these terms");
                    }
                }
            }
        }
    }
}