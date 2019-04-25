version: 1.0.{build}
image: Visual Studio 2017
install:
  - ps: choco install -y miktex
  - cmd:  refreshenv

build_script:
  - cmd: pdflatex .\Raspjamming.tex
  - cmd: pdflatex .\Raspjamming - Admin.tex
