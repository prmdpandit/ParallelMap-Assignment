# Problem Statement 

Write a .Net 6 multi-threaded program which would run locally on the machine which will perform so called limited process map operation (map phase of Map/Reduce)

Some pseudo code and interface specification below:

% lamdba functions doing some random work (CPU only, networkm, disk I/O, anything) and returns some result. Function can crash.

fun() -> do_some_work(), return_res().

% some result

res() -> any.

% perform so called "parallel map" for a arbitary list/array of lambda functions provided

% from the outside in parallel fashion with at most N processes working concurrently.

% The is also a timeout in ms provided for the the entire execution and function should throw exception if timeout was reached.

% Execution should preserve natural order of results

pmap_n (int N, [fun()], int Timeout_msec) -> [res()] | exception()

Solution

Explanation:

Structure of Solution: N-Tier (All Project in .Net 6 Framwork)

Program.cs: Contains the Main method and Consume the ParallelMap Class and instructiion code for TakFunctions(Disk I/O, Network, CPU(Image Processing)). Deendency ParallelMap-Assignment.ParallelMapLib need to take refrence.
ParallelMap-Assignment.ParallelMapLib: .Net Library which have TaskFunctions and ParallelMap with some utnity for Sop (Sepration of consorn), TaskFunctions Contains the list of functions used in the ParallelMap method. 
ParallelMapTests.cs: Contains unit tests for the ParallelMap method using NUnit. Refrence of ParallelMap-Assignment.ParallelMapLib.

Summary:

1. A CancellationTokenSource is created to manage the timeout. The CancelAfter method sets the cancellation token to trigger after the specified timeoutMs.
2. Semaphore: A SemaphoreSlim to control the number of concurrent tasks, limiting it to maxConcurrency.
3. The ParallelMapFunc method allows you to execute a list of asynchronous functions in parallel with a limit on the maximum number of concurrent tasks (maxConcurrency) and an overall timeout (timeoutMs).
4. It uses a semaphore to control concurrency, a cancellation token to manage the timeout, and handles exceptions to ensure that the operation is robust and provides meaningful error messages.
5. The method returns a list of results, preserving the order of the input functions.

output:
{"ISBN:0201558025": {"bib_key": "ISBN:0201558025", "info_url": "https://openlibrary.org/books/OL1429049M/Concrete_mathematics", "preview": "full", "preview_url": "https://archive.org/details/concretemathemat00grah_444", "thumbnail_url": "https://covers.openlibrary.org/b/id/135182-S.jpg"}, "LCCN:93005405": {"bib_key": "LCCN:93005405", "info_url": "https://openlibrary.org/books/OL1397864M/Zen_speaks", "preview": "borrow", "preview_url": "https://archive.org/details/zenspeaksshoutso0000caiz", "thumbnail_url": "https://covers.openlibrary.org/b/id/240726-S.jpg"}}
[{"name": "American University of Middle East", "alpha_two_code": "KW", "country": "Kuwait", "web_pages": ["http://www.aum.edu.kw/"], "state-province": null, "domains": ["aum.edu.kw"]}, {"name": "Middlesex County College", "alpha_two_code": "US", "country": "United States", "web_pages": ["http://www.middlesexcc.edu"], "state-province": null, "domains": ["middlesexcc.edu"]}, {"name": "Middlesex Community College", "alpha_two_code": "US", "country": "United States", "web_pages": ["http://www.middlesex.mass.edu"], "state-province": null, "domains": ["middlesex.mass.edu"]}, {"name": "Middlesex University - London", "alpha_two_code": "GB", "country": "United Kingdom", "web_pages": ["https://www.mdx.ac.uk/"], "state-province": null, "domains": ["mdx.ac.uk"]}, {"name": "Middlesbrough College", "alpha_two_code": "GB", "country": "United Kingdom", "web_pages": ["https://www.mbro.ac.uk/"], "state-province": null, "domains": ["middlesbro.ac.uk", "mbro.ac.uk"]}, {"name": "Middlebury College", "alpha_two_code": "US", "country": "United States", "web_pages": ["http://www.middlebury.edu/"], "state-province": null, "domains": ["middlebury.edu"]}, {"name": "Middle Georgia State College", "alpha_two_code": "US", "country": "United States", "web_pages": ["http://www.mga.edu/"], "state-province": null, "domains": ["mga.edu"]}, {"name": "Middle East University", "alpha_two_code": "JO", "country": "Jordan", "web_pages": ["http://www.meu.edu.jo/"], "state-province": null, "domains": ["meu.edu.jo"]}, {"name": "Middle East Technical University", "alpha_two_code": "TR", "country": "Turkey", "web_pages": ["http://www.metu.edu.tr/"], "state-province": null, "domains": ["metu.edu.tr"]}, {"name": "Middle Tennessee State University", "alpha_two_code": "US", "country": "United States", "web_pages": ["http://www.mtsu.edu/"], "state-province": null, "domains": ["mtsu.edu"]}]
Hello , Welcome to ParllalMap assignment
<?xml version="1.0" encoding="utf-8" ?>
<note>
  <to>Tove</to>
  <from>Jani</from>
  <heading>Reminder</heading>
  <body>Don't forget me this weekend!</body>
</note>

+6OOowTPBTJmRylHzRTbr07F9x+rjKwSU256U8i0ka1JtgTS6A7v0ytLEeHrbz67Zh5PFv4RIkZk1K+le76t0S5li1Imv0By7xJtqXUDC+WphHepGO40F1/GoXXFk/2Gs/jS3n1hJ+zKXmSm1qahXDla9peoX7aCACFRU3JGHMOQlOI+qfnIY6n1ig6bcX/hOkhARn29mY6B6wFbQYRgM+HluJWPf0hnfMJu7Eqq83uLX6OlYRQrdrfuAZddl4/CaVo1okwD3D2YN4CtHHEBCMtn7kw6eobx+09i/rkctlfgKbH6TUefMRnUYnUZix0kimJlzpErDiQHD7ijxxMWRq5RivSMVY5dGMuRdpsoVF8TrbN0naDNhPDvzYTdbgbN+k/ABCWxqZ9GEPHfy8cGeRSdOBgTdz5HVDNz0h7wT5kr5dg7ZuS7shyC8sDpq0x4Jw31dtqHMSXPEneJ0/CkRySclM5BQvSybPBW95JFkiwJ7/homzwZiUZUrnWgtieaPgywVJGaSf1UuOqDhrauocaheoFiUGUcC9i/TBtM7f+u4uRJV9NGBpnlRgrJua++9XAEzLu5Ld0ZdHphb5saZLIaUka+tk9lWnAZ/1GyjcA0efj4eXJA1n0sFDBKv5NvGYN+gmVXvmFYPQBCmIEfJNR6xvYlRhwIsPeSqGbWtfQNNX9OcIFJ+ENzQavuao9b7IJK/C31fN1Eqzs5x5yY4vWzl7bpq4/y8lOACxZuxWc0Tl4De+pehv/kf4AUYLzcswLDSeCeJhWGjXOBQty40fT4lsqVzVdL/OMko9CiunJCpHfBRlY0Er6ebs34jNeVRxdRZkQ22J8AXrfyQskvwrTjiTIu7wf3NezJeudNlyfgHJ2Mg9tsHvKIN38YWj5VdRgtJ1UC1ix/POiFPepLJkIsGeUOzTc2OQ5WHS5qpfzF+Bqv/sDELBJ8jvv0Hm6POld/saNIsxQwRQ2odMpJOB0Hc1yVLrChyOLF0cPEt9X/sPtqrRhXdUBmth/l62Q1ppkgoMIyt8x9CxuuYhfyh8+ru7m+9q4v6VVo1Uwk2SqAWxeCd68/ZvtEXtsXRSarQaRJahbaExQrXefkJcFtRc+mfQaQY71F/v7RidklRKxGwy+vMhosbH0/qRXTiNC8Bo1lpCcg/dsxCE9q6Iu00u8Mt85vaj3f21O6JSzCoFWPbq//GkTXe9anVUmmlcBuHK//Cj/YEm8zEtFUQCzDutmoAPNIKhNfshNyd6kiKB/59kOSbPSM6zgE22ZkoRikEWx683ccBvIIpyVJnaulC+vhkleF+7L8Z6DmeU9txmOnq7xn538+wbDa3Q6ii6sMEe7ODcpqjnFirn6fB6y3Kg==
