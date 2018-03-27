PROJECT=Raspjamming
PROJECT2=Raspjamming - Admin

TEX=pdflatex
BIBTEX=bibtex
BUILDTEX=$(TEX) "$(PROJECT).tex"
BUILDTEX2=$(TEX) "$(PROJECT2).tex"



doku:
	- ${BUILDTEX} && ${BUILDTEX} && ${BUILDTEX}

admindoku: 
	- ${BUILDTEX2} && ${BUILDTEX2} && ${BUILDTEX2}

all: clean-all doku admindoku

clean-all: clean
	- /bin/rm -f *.dvi *.ps *.eps *.pdf

clean:
	- /bin/rm -f *.log *.bak *.aux *.bbl *.blg *.idx *.toc *.out *~
