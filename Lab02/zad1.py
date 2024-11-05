from collections import Counter
import re

# Przykładowy tekst
text = """
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean sed vulputate elit.
Aliquam erat volutpat. Phasellus at arcu quis justo aliquet vulputate. Maecenas augue ex.
"""

# 1. Zliczanie słów, zdań i akapitów
words = re.findall(r'\b\w+\b', text)
sentences = re.split(r'[.!?]', text)
paragraphs = text.strip().split("\n")

word_count = len(words)
sentence_count = len([s for s in sentences if s.strip() != ''])
paragraph_count = len(paragraphs)

print("Liczba słów:", word_count)
print("Liczba zdań:", sentence_count)
print("Liczba akapitów:", paragraph_count)

# 2. Wyszukiwanie najczęściej występujących słów bez stop words
stop_words = {'i', 'a', 'the', 'and', 'of', 'in', 'to', 'with', 'on', 'at', 'by'}
filtered_words = [word.lower() for word in words if word.lower() not in stop_words]
most_common_words = Counter(filtered_words).most_common(5)

print("Najczęściej występujące słowa:", most_common_words)

# 3. Odwrotność wyrazów zaczynających się na "a" lub "A"
transformed_words = [word[::-1] if word.lower().startswith('a') else word for word in words]
transformed_text = ' '.join(transformed_words)

print("Tekst z odwróconymi wyrazami na 'a':", transformed_text)
